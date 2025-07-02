namespace AutoInsurance.Domian.AutoInsurance.AturalPersonProposals.Cadastrar
{
    public record struct CreateNaturalPersonPolicyRequest(Guid NaturalPersonProposalId, decimal Amount);
}
