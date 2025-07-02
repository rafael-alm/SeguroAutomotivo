using FastEndpoints;

namespace AutoInsurance.Domian.AutoInsurance.AturalPersonProposals.Cadastrar
{
    internal sealed class SimulateNaturalPersonProposalEndpoint : Endpoint<SimulateNaturalPersonProposalsRequest, SimulateNaturalPersonProposalsResponse>
    {
        private readonly SimulateNaturalPersonProposalsHandler _handler;

        public SimulateNaturalPersonProposalEndpoint(SimulateNaturalPersonProposalsHandler handler)
        {
            _handler = handler;
        }

        public override void Configure()
        {
            Post("/api/propostas/pessoa-fisica/simulacao");
            AllowAnonymous();
        }

        public override async Task HandleAsync(SimulateNaturalPersonProposalsRequest request, CancellationToken cancellationToken)
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
