using AutoInsurance.Domian.AutoInsurance.AturalPersonProposals;
using AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation.RiskFactors;

namespace AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation
{
    public class InsuranceCalculationContext
    {
        public DateOnly CustomerBirthDate { get; }
        public int VehicleManufactureYear { get; }
        public decimal VehicleFipeValue { get; }

        public decimal BaseAmount { get; set; }
        public List<RiskFactorData> AppliedFactors { get; } = new();

        public InsuranceCalculationContext(DateOnly customerBirthDate, int vehicleManufactureYear, decimal vehicleFipeValue)
        {
            CustomerBirthDate = customerBirthDate;
            VehicleManufactureYear = vehicleManufactureYear;
            VehicleFipeValue = vehicleFipeValue;
        }

        public void AddFactor(string description, decimal percentage)
        {
            AppliedFactors.Add(new RiskFactorData(description, percentage));
        }

        public decimal TotalRiskFactor => AppliedFactors.Sum(f => f.Percentage);
        public decimal FinalAmount => BaseAmount * (1 + TotalRiskFactor);

        public InsuranceCalculationResult ObterDetalhamento()
        {
            return new InsuranceCalculationResult
            {
                BaseAmount = BaseAmount,
                AppliedFactors = AppliedFactors.ToList(),
                TotalRiskFactor = TotalRiskFactor,
                FinalAmount = FinalAmount,
                ExecutionDate = DateTime.Now
            };
        }
    }
}
