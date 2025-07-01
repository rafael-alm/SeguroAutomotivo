using SeguroAutomotivo.Domian.SeguroAutomotivo.PropostasPessoaFisica;
using SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro.CalculoBase;
using SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro.FatoresDeRisco;

namespace SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro
{
    public class CalculadoraSeguro
    {
        private readonly ICalculoBase calculaBase;
        private readonly FatorRisco fatorRisco;

        public CalculadoraSeguro(ICalculoBase calculaBase)
        {
            this.calculaBase = calculaBase;
            this.fatorRisco = Construir();
        }

        private FatorRisco Construir()
        {
            var idadeCliente = new FatorRiscoIdadeCliente();
            var veiculoIdade = new FatorRiscoAnosVeiculo();
            var veiculoValor = new FatorRiscoValorVeiculo();

            idadeCliente
                .DefinirProximo(veiculoIdade)
                .DefinirProximo(veiculoValor);

            return idadeCliente;
        }

        public ResultaCalculoSeguro CalcularSeguro(DateTime dataNascimentoCliente, int anoFabricacaoVeiculo, decimal valorFIPEVeiculo)
        {
            var contexto = new CalculoSeguroContext(dataNascimentoCliente, anoFabricacaoVeiculo, valorFIPEVeiculo);

            contexto.ValorBase = calculaBase.CalcularValorBase(valorFIPEVeiculo);

            fatorRisco.ProcessarFator(contexto);

            return contexto.ObterDetalhamento();
        }
    }
}
