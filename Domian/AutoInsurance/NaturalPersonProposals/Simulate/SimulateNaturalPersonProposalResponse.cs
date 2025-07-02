using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoInsurance.Domian.AutoInsurance.AturalPersonProposals.Cadastrar
{
    public record struct SimulateNaturalPersonProposalsResponse(DateTime SimulationDate, decimal Amount);
}
