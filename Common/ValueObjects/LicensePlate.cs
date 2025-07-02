using AutoInsurance.Crosscutting;
using System.Text.RegularExpressions;

namespace AutoInsurance.Common.ValueObjects;

public readonly struct LicensePlate
{
    public string Code { get; init; }

    private LicensePlate(string Code)
    {
        this.Code = Code;
    }

    public static Result<LicensePlate> Create(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            return ValidationErrors.Plate.Required;

        var licensePlate = code.Trim().ToUpperInvariant();

        var regexAntiga = new Regex(@"^[A-Z]{3}[0-9]{4}$");
        var regexMercosul = new Regex(@"^[A-Z]{3}[0-9][A-Z][0-9]{2}$");

        if (!regexAntiga.IsMatch(code) && !regexMercosul.IsMatch(code))
            return ValidationErrors.Plate.InvalidFormat;

        return new LicensePlate(code);
    }
}

