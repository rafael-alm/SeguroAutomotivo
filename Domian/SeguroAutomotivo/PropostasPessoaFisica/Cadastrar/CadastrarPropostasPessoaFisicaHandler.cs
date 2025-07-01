using SeguroAutomotivo.Common;
using SeguroAutomotivo.Domian.PropostasPessoaFisica.Infrastructure.Persistence;
using SeguroAutomotivo.Domian.SeguroAutomotivo.Aggreates.PropostasPessoaFisica;

namespace SeguroAutomotivo.Domian.SeguroAutomotivo.PropostasPessoaFisica.Cadastrar
{
    internal class CadastrarPropostasPessoaFisicaHandler(PropostaPessoaFisicaRepository repository, UnitOfWork unitOfWork)
    {
        public async Task<Result<CadastrarPropostasPessoaFisicalResponse>> HandlerAsync(
            CadastrarPropostasPessoaFisicaRequest request,
            CancellationToken cancellationToken)
        {
            var propostaResult = PropostaPessoaFisica.Create(
                request.NomeCliente,
                request.CPFCliente,
                request.DataNascimentoCliente,
                request.PlacaVeiculo,
                request.AnoFabricacaoVeiculo,
                request.ValorFIPEVeiculo
            );

            if (propostaResult.TryGetValue(out var proposta, out var errors))
                return Result<CadastrarPropostasPessoaFisicalResponse>.Fail(propostaResult.Errors);

            await repository.AddAsync(proposta, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<CadastrarPropostasPessoaFisicalResponse>.Ok(new (proposta.Id.ToString(), proposta.NomeCliente));
        }
    }
}
