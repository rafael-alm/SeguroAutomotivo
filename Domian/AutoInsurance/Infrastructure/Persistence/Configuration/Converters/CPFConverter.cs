using AutoInsurance.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoInsurance.Domian.AutoInsurance.Infrastructure.Persistence.Configuration.Converters
{
    internal sealed class CPFConverter : ValueConverter<CPF, string>
    {
        public CPFConverter() : base(
            cpf => cpf.Numero,
            numero => CPF.Create(numero).Value)
        {
        }
    }
}
