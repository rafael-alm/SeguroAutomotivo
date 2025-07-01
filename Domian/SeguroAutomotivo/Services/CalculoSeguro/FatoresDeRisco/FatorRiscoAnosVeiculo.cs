namespace SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro.FatoresDeRisco
{
    internal class FatorRiscoAnosVeiculo : FatorRisco
    {
        public override CalculoSeguroContext ProcessarFator(CalculoSeguroContext contexto)
        {
            int quantidadeAnosVeiculo = DateTime.Now.Year - contexto.AnoFabricacaoVeiculo;

            if (quantidadeAnosVeiculo > 10)
                contexto.AdicionarFator("Veículo > 10 anos", 0.15m);

            return base.ProcessarFator(contexto);
        }
    }
}
