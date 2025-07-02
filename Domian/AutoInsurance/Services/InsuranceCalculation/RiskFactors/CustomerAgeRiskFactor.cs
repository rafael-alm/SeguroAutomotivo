namespace AutoInsurance.Domian.AutoInsurance.Services.InsuranceCalculation.RiskFactors
{
    public class CustomerAgeRiskFactor : RiskFactor
    {
        public override InsuranceCalculationContext ProcessFactor(InsuranceCalculationContext contexto)
        {
            var idade = calculateAge(contexto.CustomerBirthDate);

            if (idade < 25)
            {
                contexto.AddFactor("Idade < 25 anos", 0.20m);
            }
            else if (idade > 60)
            {
                contexto.AddFactor("Idade > 60 anos", 0.30m);
            }

            return base.ProcessFactor(contexto);
        }
        //TODO: Colocar em outro lugar
        private int calculateAge(DateOnly birthDate)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }
    }
}
