using AutoInsurance.Domian.AutoInsurance.Infrastructure.Persistence;
using AutoInsurance.Domian.AutoInsurance.AturalPersonProposals;
using AutoInsurance.Domian.AutoInsurance.AturalPersonProposals.Cadastrar;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace AutoInsurance.Domian.Orchestration.PolicyIssuance.Steps;

internal sealed class IssuePolicyStep(
    CreateNaturalPersonPolicyHandler createNaturalPersonPolicyHandler,
    NaturalPersonProposalRepository repository,
    UnitOfWork unitOfWork) : StepBodyAsync
{
    public string ProposalId { get; set; }

    public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
    {
        var proposal = await repository.GetAsync(Guid.Parse(ProposalId), context.CancellationToken);
        proposal.Processing();

        var request = new CreateNaturalPersonPolicyRequest { NaturalPersonProposalId = proposal.Id, Amount = proposal.ProposalAmount};
        var createNaturalPersonPolicyResult = await createNaturalPersonPolicyHandler.HandlerAsync(request, context.CancellationToken);

        if (!createNaturalPersonPolicyResult.Success)
            throw new InvalidOperationException(
                $"Failed to issue policy for proposal {proposal.Id}: {string.Join(", ", createNaturalPersonPolicyResult.Errors.Select(e => e.Message))}");

        await unitOfWork.SaveChangesAsync(context.CancellationToken);

        return ExecutionResult.Next();
    }
}