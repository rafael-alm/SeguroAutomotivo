using AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonProposals;

namespace AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation.BaseCalculation
{
    public interface IBaseCalculation
    {
        decimal CalculateBaseValue(decimal FIPEValue);
        InsuranceType InsuranceType { get; }
    }
}
