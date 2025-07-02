using AutoInsurance.Common;
using AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation;

namespace AutoInsurance.Domian.AutoInsurance.AturalPersonProposals.Cadastrar
{
    internal sealed class SimulateNaturalPersonProposalsHandler()
    {
        public async Task<Result<SimulateNaturalPersonProposalsResponse>> HandleAsync(
            SimulateNaturalPersonProposalsRequest request,
            CancellationToken cancellationToken)
        {
            var calculadora = InsuranceCalculatorFactory.Create(request.InsuranceType);
            var resultado = calculadora.CalculateInsurance(request.CustomerBirthDate, request.VehicleManufactureYear, request.VehicleFipeValue);

            return Result<SimulateNaturalPersonProposalsResponse>.Ok(new(resultado.ExecutionDate, resultado.FinalAmount));
        }
    }
}
