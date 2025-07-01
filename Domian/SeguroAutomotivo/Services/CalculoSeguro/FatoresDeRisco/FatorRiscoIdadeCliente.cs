namespace SeguroAutomotivo.Domian.SeguroAutomotivo.Services.CalculoSeguro.FatoresDeRisco
{
    public class FatorRiscoIdadeCliente : FatorRisco
    {
        public override CalculoSeguroContext ProcessarFator(CalculoSeguroContext contexto)
        {
            var idade = calcularIdade(contexto.DataNascimentoCliente);

            if (idade < 25)
            {
                contexto.AdicionarFator("Idade < 25 anos", 0.20m);
            }
            else if (idade > 60)
            {
                contexto.AdicionarFator("Idade > 60 anos", 0.30m);
            }

            return base.ProcessarFator(contexto);
        }
        //TODO: Colocar em outro lugar
        private int calcularIdade(DateTime dataNascimento)
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - dataNascimento.Year;
            if (dataNascimento.Date > hoje.AddYears(-idade)) idade--;
            return idade;
        }
    }
}
