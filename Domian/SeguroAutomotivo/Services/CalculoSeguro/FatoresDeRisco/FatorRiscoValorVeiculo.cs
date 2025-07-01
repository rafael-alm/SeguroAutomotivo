namespace SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro.FatoresDeRisco
{
    internal class FatorRiscoValorVeiculo : FatorRisco
    {
        public override CalculoSeguroContext ProcessarFator(CalculoSeguroContext contexto)
        {
            if (contexto.ValorFIPEVeiculo > 100000m)
                contexto.AdicionarFator("Veículo > R$ 100.000", 0.10m);

            return base.ProcessarFator(contexto);
        }
    }
}
