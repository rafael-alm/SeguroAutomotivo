using SeguroAutomotivo.Common;

namespace SeguroAutomotivo.Crosscutting
{
    public static class ValidationErrors
    {
        

        public static class CPF
        {
            public static readonly ErrorMessage InvalidFormat = new("INVALID_CPF", "O CPF informado é inválido");
            public static readonly ErrorMessage Required = new("CPF_REQUIRED", "O CPF é obrigatória");
        }
        public static class Placa
        {
            public static readonly ErrorMessage Required = new("PLACA_REQUIRED", "A placa é obrigatória");
            public static readonly ErrorMessage InvalidFormat = new("INVALID_PLACA_FORMAT", "O formato da placa é inválido");
        }
        public static class PropostaPessoaFisica
        {
            
            public static readonly ErrorMessage NameIsRequired = new ("NAME_IS_REQUIRED", "Name is required.");   
            public static readonly ErrorMessage ManufactureYearInvalid = new ( "MANUFACTURE_YEAR_INVALID", "The manufacture year is invalid.");   
        }
    }
}
