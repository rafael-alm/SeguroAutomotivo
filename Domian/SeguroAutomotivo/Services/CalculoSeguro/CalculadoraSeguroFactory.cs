using SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro.CalculoBase;

namespace SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro
{
    public class CalculadoraSeguroFactory
    {
        public static CalculadoraSeguro CriarCalculadora(TipoSeguro tipo)
        {
            ICalculoBase calculoBase = tipo switch
            {
                TipoSeguro.Basico => new CalculoSeguroBasico(),
                TipoSeguro.Completo => new CalculoSeguroCompleto(),
                TipoSeguro.Premium => new CalculoSeguroPremium(),
                _ => throw new ArgumentException("Tipo de seguro inválido")
            };

            return new CalculadoraSeguro(calculoBase);
        }
    }
}
