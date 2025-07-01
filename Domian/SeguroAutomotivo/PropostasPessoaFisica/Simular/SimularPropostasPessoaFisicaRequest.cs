namespace SeguroAutomotivo.Domian.SeguroAutomotivo.PropostasPessoaFisica.Cadastrar
{
    public record struct SimularPropostasPessoaFisicaRequest(
        TipoSeguro TipoSeguro,
        DateTime DataNascimentoCliente, 
        int AnoFabricacaoVeiculo, 
        decimal ValorFIPEVeiculo);
}
