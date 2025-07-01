using SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro.FatoresDeRisco;

namespace SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro
{
    public struct ResultaCalculoSeguro
    {
        public decimal ValorBase { get; set; }
        public List<FatorRiscoDTO> FatoresAplicados { get; set; }
        public decimal FatorTotalRisco { get; set; }
        public decimal ValorFinal { get; set; }
        public DateTime DataExecucao { get; set; }
    }
}
