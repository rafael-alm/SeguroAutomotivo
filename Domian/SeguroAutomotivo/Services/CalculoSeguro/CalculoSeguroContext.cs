using SeguroAutomotivo.Domian.SeguroAutomotivo.PropostasPessoaFisica;
using SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro.FatoresDeRisco;

namespace SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro
{
    public class CalculoSeguroContext
    {
        public DateTime DataNascimentoCliente { get; }
        public int AnoFabricacaoVeiculo { get; }
        public decimal ValorFIPEVeiculo { get; }

        public decimal ValorBase { get; set; }
        public List<FatorRiscoDTO> FatoresAplicados { get; } = new();

        public CalculoSeguroContext(DateTime dataNascimentoCliente, int anoFabricacaoVeiculo, decimal valorFIPEVeiculo)
        {
            DataNascimentoCliente = dataNascimentoCliente;
            AnoFabricacaoVeiculo = anoFabricacaoVeiculo;
            ValorFIPEVeiculo = valorFIPEVeiculo;
        }

        public void AdicionarFator(string descricao, decimal percentual)
        {
            FatoresAplicados.Add(new FatorRiscoDTO(descricao, percentual));
        }

        public decimal FatorTotalRisco => FatoresAplicados.Sum(f => f.Percentual);
        public decimal ValorFinal => ValorBase * (1 + FatorTotalRisco);

        public ResultaCalculoSeguro ObterDetalhamento()
        {
            return new ResultaCalculoSeguro
            {
                ValorBase = ValorBase,
                FatoresAplicados = FatoresAplicados.ToList(),
                FatorTotalRisco = FatorTotalRisco,
                ValorFinal = ValorFinal,
                DataExecucao = DateTime.Now
            };
        }
    }
}
