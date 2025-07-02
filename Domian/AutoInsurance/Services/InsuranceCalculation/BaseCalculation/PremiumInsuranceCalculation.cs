using AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonProposals;

namespace AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation.BaseCalculation
{
    public class PremiumInsuranceCalculation : IBaseCalculation
    {
        private const decimal BASE_RATE = 0.06m;

        public InsuranceType InsuranceType => InsuranceType.Premium;

        public decimal CalculateBaseValue(decimal valorFIPE)
        {
            return valorFIPE * BASE_RATE;
        }
    }
}
