namespace AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation.RiskFactors
{
    internal class VehicleValueRiskFactor : RiskFactor
    {
        public override InsuranceCalculationContext ProcessFactor(InsuranceCalculationContext contexto)
        {
            if (contexto.VehicleFipeValue > 100000m)
                contexto.AddFactor("Veículo > R$ 100.000", 0.10m);

            return base.ProcessFactor(contexto);
        }
    }
}
