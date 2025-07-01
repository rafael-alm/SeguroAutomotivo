namespace SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro.CalculoBase
{
    public class CalculoSeguroPremium : ICalculoBase
    {
        private const decimal TAXA_BASE = 0.06m;

        public TipoSeguro TipoSeguro => TipoSeguro.Premium;

        public decimal CalcularValorBase(decimal valorFIPE)
        {
            return valorFIPE * TAXA_BASE;
        }
    }
}
