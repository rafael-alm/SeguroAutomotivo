using FastEndpoints;

namespace AutoInsurance.Domian.AutoInsurance.AturalPersonProposals.Cadastrar
{
    internal class CreateNaturalPersonProposalEndpoint : Endpoint<CreateNaturalPersonProposalRequest, CreateNaturalPersonProposalResponse>
    {
        private readonly CreateNaturalPersonProposalHandler handler;

        public CreateNaturalPersonProposalEndpoint(CreateNaturalPersonProposalHandler handler)
        {
            this.handler = handler;
        }

        public override void Configure()
        {
            Post("/api/proposals/natural-person");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateNaturalPersonProposalRequest request, CancellationToken cancellationToken)
        {
            var result = await handler.HandlerAsync(request, cancellationToken);

            if (result.Success)
            {
                await SendOkAsync(result.Value, cancellationToken);
                return;
            }

            await SendErrorsAsync(cancellation: cancellationToken);
        }
    }
}
