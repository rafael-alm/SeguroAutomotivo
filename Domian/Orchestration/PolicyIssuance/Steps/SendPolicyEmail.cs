using AutoInsurance.Domian.AutoInsurance.Infrastructure.Persistence;
using AutoInsurance.Domian.AutoInsurance.AturalPersonProposals;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace AutoInsurance.Domian.Orchestration.PolicyIssuance.Steps;

internal sealed class SendPolicyEmail(NaturalPersonProposalRepository repository, UnitOfWork unitOfWork) : StepBodyAsync
{
    public string ProposalId { get; set; }

    public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
    {
        var proposal = await repository.GetAsync(Guid.Parse(ProposalId), context.CancellationToken);
        proposal.Processed();
        await unitOfWork.SaveChangesAsync(context.CancellationToken);

        return ExecutionResult.Next();
    }
}