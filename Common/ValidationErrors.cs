using AutoInsurance.Common;

namespace AutoInsurance.Crosscutting
{
    public static class ValidationErrors
    {


        public static class CPF
        {
            public static readonly ErrorMessage InvalidFormat = new("INVALID_CPF", "O CPF informado é inválido");
            public static readonly ErrorMessage Required = new("CPF_REQUIRED", "O CPF é obrigatória");
        }
        public static class Plate
        {
            public static readonly ErrorMessage Required = new("PLACA_REQUIRED", "A placa é obrigatória");
            public static readonly ErrorMessage InvalidFormat = new("INVALID_PLACA_FORMAT", "O formato da placa é inválido");
        }
        public static class NaturalPersonProposal
        {

            public static readonly ErrorMessage NameIsRequired = new("NAME_IS_REQUIRED", "Name is required.");
            public static readonly ErrorMessage ManufactureYearInvalid = new("MANUFACTURE_YEAR_INVALID", "The manufacture year is invalid.");
            public static readonly ErrorMessage AmountValueMustBeGreaterThanZero = new("POLICY_NUMBER_INVALID", "Não são permitidos valores menores ou iguais a zero.");
        }

        public static class NaturalPersonPolicy
        {
            public static readonly ErrorMessage StartCoverageDateInPastMessage = new("POLICY_NUMBER_REQUIRED", "A data de início da cobertura não pode ser anterior à data de hoje.");
            public static readonly ErrorMessage AmountValueMustBeGreaterThanZero = new("POLICY_NUMBER_INVALID", "Não são permitidos valores menores ou iguais a zero.");
        }
    }
}
