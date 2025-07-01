namespace SeguroAutomotivo.Domian.SeguroAutomotivo.PropostasPessoaFisica.Cadastrar
{
    public record struct CadastrarPropostasPessoaFisicaRequest(string NomeCliente, string CPFCliente, DateTime DataNascimentoCliente, string PlacaVeiculo, int AnoFabricacaoVeiculo, decimal ValorFIPEVeiculo);
}
