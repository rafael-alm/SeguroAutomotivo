using SeguroAutomotivo.Domian.SeguroAutomotivo.PropostasPessoaFisica;

namespace SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro.FatoresDeRisco
{
    public abstract class FatorRisco
    {
        protected FatorRisco proximo;

        public FatorRisco DefinirProximo(FatorRisco fatorRisco)
        {
            proximo = fatorRisco;
            return fatorRisco;
        }

        public virtual CalculoSeguroContext ProcessarFator(CalculoSeguroContext contexto)
        {
            if (proximo != null)
                return proximo.ProcessarFator(contexto);

            return contexto;
        }
    }

    public record FatorRiscoDTO(string Descricao, decimal Percentual);
}
