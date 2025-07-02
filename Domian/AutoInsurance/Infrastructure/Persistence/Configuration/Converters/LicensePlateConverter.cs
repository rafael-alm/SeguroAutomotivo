using AutoInsurance.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoInsurance.Domian.AutoInsurance.Infrastructure.Persistence.Configuration.Converters
{
    internal sealed class LicensePlateConverter : ValueConverter<LicensePlate, string>
    {
        public LicensePlateConverter() : base(
            licensePlate => licensePlate.Code,
            code => LicensePlate.Create(code).Value)
        {
        }
    }
}
