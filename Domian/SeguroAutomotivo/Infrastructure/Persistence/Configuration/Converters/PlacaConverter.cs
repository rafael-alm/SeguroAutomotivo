using SeguroAutomotivo.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SeguroAutomotivo.Domian.PropostasPessoaFisica.Infrastructure.Persistence.Configuration.Converters
{
    internal sealed class PlacaConverter : ValueConverter<Placa, string>
    {
        public PlacaConverter() : base(
            placa => placa.Codigo,
            codigo => Placa.Create(codigo).Value)
        {
        }
    }
}
