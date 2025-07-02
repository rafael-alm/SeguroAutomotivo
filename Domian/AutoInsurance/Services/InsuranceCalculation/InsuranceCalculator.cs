using AutoInsurance.Domian.AutoInsurance.AturalPersonProposals;
using AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation.BaseCalculation;
using AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation.RiskFactors;

namespace AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation
{
    public class InsuranceCalculator
    {
        private readonly IBaseCalculation calculaBase;
        private readonly RiskFactor fatorRisco;

        public InsuranceCalculator(IBaseCalculation calculaBase)
        {
            this.calculaBase = calculaBase;
            this.fatorRisco = Construir();
        }

        private RiskFactor Construir()
        {
            var idadeCliente = new CustomerAgeRiskFactor();
            var veiculoIdade = new VehicleAgeRiskFactor();
            var veiculoValor = new VehicleValueRiskFactor();

            idadeCliente
                .SetNext(veiculoIdade)
                .SetNext(veiculoValor);

            return idadeCliente;
        }

        public InsuranceCalculationResult CalculateInsurance(DateOnly customerBirthDate, int vehicleManufactureYear, decimal vehicleFipeValue)
        {
            var contexto = new InsuranceCalculationContext(customerBirthDate, vehicleManufactureYear, vehicleFipeValue);

            contexto.BaseAmount = calculaBase.CalculateBaseValue(vehicleFipeValue);

            fatorRisco.ProcessFactor(contexto);

            return contexto.ObterDetalhamento();
        }
    }
}
