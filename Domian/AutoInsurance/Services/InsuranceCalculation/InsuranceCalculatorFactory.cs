using AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonProposals;
using AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation.BaseCalculation;

namespace AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation
{
    public class InsuranceCalculatorFactory
    {
        public static InsuranceCalculator Create(InsuranceType tipo)
        {
            IBaseCalculation baseCalculation = tipo switch
            {
                InsuranceType.Basic => new BasicInsuranceCalculation(),
                InsuranceType.Full => new FullInsuranceCalculation(),
                InsuranceType.Premium => new PremiumInsuranceCalculation(),
                _ => throw new ArgumentException("Tipo de seguro inválido")
            };

            return new InsuranceCalculator(baseCalculation);
        }
    }
}
