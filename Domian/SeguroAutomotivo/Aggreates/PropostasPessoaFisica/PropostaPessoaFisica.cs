using SeguroAutomotivo.Common;
using SeguroAutomotivo.Common.ValueObjects;
using SeguroAutomotivo.Crosscutting;

namespace SeguroAutomotivo.Domian.SeguroAutomotivo.Aggreates.PropostasPessoaFisica
{
    internal sealed class PropostaPessoaFisica : Entity, IAggregate
    {
        private PropostaPessoaFisica() { }

        private PropostaPessoaFisica(
            DateTime dataCriacao, 
            string nomeCliente, 
            CPF cpfCliente, 
            DateTime dataNascimentoCliente, 
            Placa placaVeiculo, 
            int anoFabricacaoVeiculo, 
            decimal valorFIPEVeiculo)
        {
            DataCriacao = dataCriacao;
            NomeCliente = nomeCliente;
            CPFCliente = cpfCliente;
            DataNascimentoCliente = dataNascimentoCliente;
            PlacaVeiculo = placaVeiculo;
            AnoFabricacaoVeiculo = anoFabricacaoVeiculo;
            ValorFIPEVeiculo = valorFIPEVeiculo;
        }

        public DateTime DataCriacao { get; set; }
        public string NomeCliente { get; set; }
        public CPF CPFCliente { get; set; }
        public DateTime DataNascimentoCliente { get; set; }
        public Placa PlacaVeiculo { get; set; }
        public int AnoFabricacaoVeiculo { get; set; }
        public decimal ValorFIPEVeiculo { get; set; }

        public static Result<PropostaPessoaFisica> Create(
            string nomeCliente, 
            string cpfCliente, 
            DateTime dataNascimentoCliente, 
            string placaVeiculo, 
            int anoFabricacaoVeiculo, 
            decimal valorFIPEVeiculo)
        {
            List<ErrorMessage> validationErrors = new List<ErrorMessage>();

            var cpfResult = CPF.Create(cpfCliente);
            if (!cpfResult.TryGetValue(out var _cpf, out var cpfErrors))
                validationErrors.AddRange(cpfErrors);

            var placaResult = Placa.Create(placaVeiculo);
            if (!placaResult.TryGetValue(out var _placa, out var placaErrors))
                validationErrors.AddRange(placaErrors);

            if (string.IsNullOrWhiteSpace(nomeCliente))
                validationErrors.Add(ValidationErrors.PropostaPessoaFisica.NameIsRequired);

            if (anoFabricacaoVeiculo < 1886 || anoFabricacaoVeiculo > DateTime.Now.AddYears(1).Year)
                validationErrors.Add(ValidationErrors.PropostaPessoaFisica.NameIsRequired);

            return new PropostaPessoaFisica(DateTime.Now, nomeCliente, _cpf, dataNascimentoCliente, _placa, anoFabricacaoVeiculo, valorFIPEVeiculo);
        }
    }
}
