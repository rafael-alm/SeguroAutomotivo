using AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonProposals;

namespace AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation.BaseCalculation
{
    public class BasicInsuranceCalculation : IBaseCalculation
    {
        private const decimal BASE_RATE = 0.06m;

        public InsuranceType InsuranceType => InsuranceType.Basic;

        public decimal CalculateBaseValue(decimal FIPEValue)
        {
            return FIPEValue * BASE_RATE;
        }
    }
}
