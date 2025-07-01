using FastEndpoints;

namespace SeguroAutomotivo.Domian.SeguroAutomotivo.PropostasPessoaFisica.Cadastrar
{
    internal class CadastrarPropostasPessoaFisicaEndpoint : Endpoint<CadastrarPropostasPessoaFisicaRequest, CadastrarPropostasPessoaFisicalResponse>
    {
        private readonly CadastrarPropostasPessoaFisicaHandler _handler;

        public CadastrarPropostasPessoaFisicaEndpoint(CadastrarPropostasPessoaFisicaHandler handler)
        {
            _handler = handler;
        }

        public override void Configure()
        {
            Post("/api/propostas/pessoa-fisica");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CadastrarPropostasPessoaFisicaRequest request, CancellationToken cancellationToken)
        {
            var result = await _handler.HandlerAsync(request, cancellationToken);

            if (result.Success)
            {
                await SendOkAsync(result.Value, cancellationToken);
                return;
            }

            await SendErrorsAsync(cancellation: cancellationToken);
        }
    }
}
