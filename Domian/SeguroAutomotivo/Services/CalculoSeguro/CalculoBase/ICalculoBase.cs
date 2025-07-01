namespace SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro.CalculoBase
{
    public interface ICalculoBase
    {
        decimal CalcularValorBase(decimal valorFIPE);
        TipoSeguro TipoSeguro { get; }
    }
}
