using SeguroAutomotivo.Crosscutting;
using System.Text.RegularExpressions;

namespace SeguroAutomotivo.Common.ValueObjects;

public readonly struct CPF
{
    public string Numero { get; init; }

    private CPF(string numero)
    {
        Numero = numero;
    }

    public static Result<CPF> Create(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero))
            return ValidationErrors.CPF.Required;

        if (!ValidarDigitosVerificadores(numero))
            return ValidationErrors.CPF.InvalidFormat;

        return new CPF(numero);
    }

    private static bool ValidarDigitosVerificadores(string numero)
    {
        if (new string(numero[0], numero.Length) == numero)
            return false;

        int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        var tempCpf = numero.Substring(0, 9);
        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        int resto = soma % 11;
        int digito1 = resto < 2 ? 0 : 11 - resto;

        tempCpf += digito1;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        int digito2 = resto < 2 ? 0 : 11 - resto;

        return numero.EndsWith($"{digito1}{digito2}");
    }
}

