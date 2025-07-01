using FastEndpoints;

namespace SeguroAutomotivo.Domian.SeguroAutomotivo.PropostasPessoaFisica.Cadastrar
{
    internal sealed class SimularPropostasPessoaFisicaEndpoint : Endpoint<SimularPropostasPessoaFisicaRequest, SimularPropostasPessoaFisicalResponse>
    {
        private readonly SimularPropostasPessoaFisicaHandler _handler;

        public SimularPropostasPessoaFisicaEndpoint(SimularPropostasPessoaFisicaHandler handler)
        {
            _handler = handler;
        }

        public override void Configure()
        {
            Post("/api/propostas/pessoa-fisica/simulacao");
            AllowAnonymous();
        }

        public override async Task HandleAsync(SimularPropostasPessoaFisicaRequest request, CancellationToken cancellationToken)
        {
            var result = await _handler.HandleAsync(request, cancellationToken);

            if (result.Success)
            {
                await SendOkAsync(result.Value, cancellationToken);
                return;
            }

            await SendErrorsAsync(cancellation: cancellationToken);
        }
    }
}
