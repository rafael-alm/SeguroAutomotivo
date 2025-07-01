namespace SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro.CalculoBase
{
    public class CalculoSeguroCompleto : ICalculoBase
    {
        private const decimal TAXA_BASE = 0.06m;

        public TipoSeguro TipoSeguro => TipoSeguro.Completo;

        public decimal CalcularValorBase(decimal valorFIPE)
        {
            return valorFIPE * TAXA_BASE;
        }
    }
}
