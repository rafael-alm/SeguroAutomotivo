using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace AutoInsurance.Domian.Orchestration.PolicyIssuance.Steps;

internal sealed class IssueNFSStep() : StepBodyAsync
{
    public string ProposalId { get; set; }

    public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
    {
        return ExecutionResult.Next();
    }
}