using AutoInsurance.Domian.Orchestration.PolicyIssuance.Steps;
using WorkflowCore.Interface;

namespace AutoInsurance.Domian.Orchestration.PolicyIssuance;

public class PolicyIssuanceWorkflowDefinition : IWorkflow<PolicyIssuanceWorkflowData>
{
    public string Id => "policy-issuance-workflow";
    public int Version => 1;

    public void Build(IWorkflowBuilder<PolicyIssuanceWorkflowData> builder)
    {
        builder
            .StartWith<IssuePolicyStep>()
            .Saga(saga => saga
                .StartWith<IssuePolicyStep>()
                    .Input(step => step.ProposalId, data => data.ProposalId)
                .Then<IssueNFSStep>()
                    .Input(step => step.ProposalId, data => data.ProposalId)
                .Then<SendPolicyEmail> ()
                    .Input(step => step.ProposalId, data => data.ProposalId)
                .CompensateWith<IssuePolicyCompensationStep>());
    }
}