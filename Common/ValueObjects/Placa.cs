using SeguroAutomotivo.Crosscutting;
using System.Text.RegularExpressions;

namespace SeguroAutomotivo.Common.ValueObjects;

public readonly struct Placa
{
    public string Codigo { get; init; }

    private Placa(string codigo)
    {
        Codigo = codigo;
    }

    public static Result<Placa> Create(string codigo)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            return ValidationErrors.Placa.Required;

        var placa = codigo.Trim().ToUpperInvariant();

        var regexAntiga = new Regex(@"^[A-Z]{3}[0-9]{4}$");
        var regexMercosul = new Regex(@"^[A-Z]{3}[0-9][A-Z][0-9]{2}$");

        if (!regexAntiga.IsMatch(codigo) && !regexMercosul.IsMatch(codigo))
            return ValidationErrors.Placa.InvalidFormat;

        return new Placa(codigo);
    }
}

