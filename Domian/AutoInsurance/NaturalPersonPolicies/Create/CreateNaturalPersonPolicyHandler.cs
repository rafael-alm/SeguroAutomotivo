using AutoInsurance.Common;
using AutoInsurance.Domian.AutoInsurance.Infrastructure.Persistence;
using AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonPolicies;
using WorkflowCore.Interface;

namespace AutoInsurance.Domian.AutoInsurance.AturalPersonProposals.Cadastrar
{
    internal class CreateNaturalPersonPolicyHandler(NaturalPersonPolicyRepository repository, UnitOfWork unitOfWork)
    {
        public async Task<Result<CreateNaturalPersonPolicyResponse>> HandlerAsync(
            CreateNaturalPersonPolicyRequest request,
            CancellationToken cancellationToken)
        {
            var policyResult = NaturalPersonPolicy.Create(
                request.NaturalPersonProposalId,
                request.Amount
            );

            if (policyResult.TryGetValue(out var policy, out var errors))
                return Result<CreateNaturalPersonPolicyResponse>.Fail(policyResult.Errors);

            await repository.AddAsync(policy, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<CreateNaturalPersonPolicyResponse>.Ok(new(policy.Id));
        }
    }
}
