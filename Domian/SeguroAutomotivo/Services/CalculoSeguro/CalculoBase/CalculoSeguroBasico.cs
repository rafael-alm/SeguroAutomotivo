namespace SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro.CalculoBase
{
    public class CalculoSeguroBasico : ICalculoBase
    {
        private const decimal TAXA_BASE = 0.06m;

        public TipoSeguro TipoSeguro => TipoSeguro.Basico;

        public decimal CalcularValorBase(decimal valorFIPE)
        {
            return valorFIPE * TAXA_BASE;
        }
    }
}
