using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace AutoInsurance.Domian.Orchestration.PolicyIssuance.Steps;

public class IssuePolicyCompensationStep() : StepBodyAsync
{
    public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
    {
        return ExecutionResult.Next();
    }
}