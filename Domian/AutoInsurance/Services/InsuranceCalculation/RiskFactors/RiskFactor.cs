using AutoInsurance.Domian.AutoInsurance.AturalPersonProposals;

namespace AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation.RiskFactors
{
    public abstract class RiskFactor
    {
        protected RiskFactor next;

        public RiskFactor SetNext(RiskFactor riskFactor)
        {
            next = riskFactor;
            return riskFactor;
        }

        public virtual InsuranceCalculationContext ProcessFactor(InsuranceCalculationContext contexto)
        {
            if (next != null)
                return next.ProcessFactor(contexto);

            return contexto;
        }
    }

    public record RiskFactorData(string Description, decimal Percentage);
}
