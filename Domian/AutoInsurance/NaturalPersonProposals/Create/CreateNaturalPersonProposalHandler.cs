using AutoInsurance.Common;
using AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonProposals;
using AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation;
using AutoInsurance.Domian.Orchestration.PolicyIssuance;
using AutoInsurance.Domian.AutoInsurance.Infrastructure.Persistence;
using WorkflowCore.Interface;

namespace AutoInsurance.Domian.AutoInsurance.AturalPersonProposals.Cadastrar
{
    internal class CreateNaturalPersonProposalHandler(NaturalPersonProposalRepository repository, UnitOfWork unitOfWork, IWorkflowHost workflowHost)
    {
        public async Task<Result<CreateNaturalPersonProposalResponse>> HandlerAsync(
            CreateNaturalPersonProposalRequest request,
            CancellationToken cancellationToken)
        {
            var calculator = InsuranceCalculatorFactory.Create(request.InsuranceType);
            var result = calculator.CalculateInsurance(request.CustomerBirthDate, request.VehicleManufactureYear, request.VehicleFipeValue);

            var proposalResult = NaturalPersonProposal.Create(
                request.CustomerName,
                request.CustomerCPF,
                request.CustomerBirthDate,
                request.VehicleLicensePlate,
                request.VehicleManufactureYear,
                request.VehicleFipeValue,
                result.FinalAmount
            );

            if (!proposalResult.TryGetValue(out var proposal, out var errors))
                return Result<CreateNaturalPersonProposalResponse>.Fail(proposalResult.Errors);

            await repository.AddAsync(proposal, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            await workflowHost.StartWorkflow("policy-issuance-workflow", new PolicyIssuanceWorkflowData { ProposalId = proposal.Id.ToString() });

            return Result<CreateNaturalPersonProposalResponse>.Ok(new (proposal.Id.ToString(), proposal.CustomerName));
        }
    }
}
