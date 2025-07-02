using AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation.RiskFactors;

namespace AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation
{
    public struct InsuranceCalculationResult
    {
        public decimal BaseAmount { get; set; }
        public List<RiskFactorData> AppliedFactors { get; set; }
        public decimal TotalRiskFactor { get; set; }
        public decimal FinalAmount { get; set; }
        public DateTime ExecutionDate { get; set; }
    }
}
