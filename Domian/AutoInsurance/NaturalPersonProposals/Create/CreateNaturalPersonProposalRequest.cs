using AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonProposals;

namespace AutoInsurance.Domian.AutoInsurance.AturalPersonProposals.Cadastrar
{
    public record struct CreateNaturalPersonProposalRequest(
        string CustomerName, 
        string CustomerCPF,
        DateOnly CustomerBirthDate, 
        string VehicleLicensePlate, 
        int VehicleManufactureYear, 
        decimal VehicleFipeValue,
        InsuranceType InsuranceType);
}
