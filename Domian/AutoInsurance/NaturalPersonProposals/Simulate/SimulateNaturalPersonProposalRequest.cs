using AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonProposals;

namespace AutoInsurance.Domian.AutoInsurance.AturalPersonProposals.Cadastrar
{
    public record struct SimulateNaturalPersonProposalsRequest(
        InsuranceType InsuranceType,
        DateOnly CustomerBirthDate, 
        int VehicleManufactureYear, 
        decimal VehicleFipeValue);
}
