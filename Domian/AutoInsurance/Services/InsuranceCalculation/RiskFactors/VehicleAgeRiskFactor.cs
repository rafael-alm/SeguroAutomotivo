namespace AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation.RiskFactors
{
    internal class VehicleAgeRiskFactor : RiskFactor
    {
        public override InsuranceCalculationContext ProcessFactor(InsuranceCalculationContext contexto)
        {
            int vehicleAgeInYears = DateTime.Now.Year - contexto.VehicleManufactureYear;

            if (vehicleAgeInYears > 10)
                contexto.AddFactor("Veículo > 10 anos", 0.15m);

            return base.ProcessFactor(contexto);
        }
    }
}
