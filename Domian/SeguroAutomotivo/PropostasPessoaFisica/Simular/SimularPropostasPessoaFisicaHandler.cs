using SeguroAutomotivo.Common;
using SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro;

namespace SeguroAutomotivo.Domian.SeguroAutomotivo.PropostasPessoaFisica.Cadastrar
{
    internal sealed class SimularPropostasPessoaFisicaHandler()
    {
        public async Task<Result<SimularPropostasPessoaFisicalResponse>> HandleAsync(
            SimularPropostasPessoaFisicaRequest request,
            CancellationToken cancellationToken)
        {
            var calculadora = CalculadoraSeguroFactory.CriarCalculadora(request.TipoSeguro);
            var resultado = calculadora.CalcularSeguro(request.DataNascimentoCliente, request.AnoFabricacaoVeiculo, request.ValorFIPEVeiculo);

            return Result<SimularPropostasPessoaFisicalResponse>.Ok(new(resultado.DataExecucao, resultado.ValorFinal));
        }
    }
}
