using AutoInsurance.Common;
using AutoInsurance.Common.ValueObjects;
using AutoInsurance.Crosscutting;

namespace AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonProposals
{
    internal sealed class NaturalPersonProposal : Entity, IAggregate
    {
        private NaturalPersonProposal() { }

        private NaturalPersonProposal(
            string customerName,
            CPF customerCPF,
            DateOnly customerBirthDate,
            LicensePlate vehicleLicensePlate,
            int vehicleManufactureYear,
            decimal vehicleFipeValue,
            ProposalStatus status,
            decimal proposalAmount)
        {
            CustomerName = customerName;
            CustomerCPF = customerCPF;
            CustomerBirthDate = customerBirthDate;
            VehicleLicensePlate = vehicleLicensePlate;
            VehicleManufactureYear = vehicleManufactureYear;
            VehicleFipeValue = vehicleFipeValue;
            Status = status;
            ProposalAmount = proposalAmount;
        }

        public string CustomerName { get; private set; }
        public CPF CustomerCPF { get; private set; }
        public DateOnly CustomerBirthDate { get; private set; }
        public LicensePlate VehicleLicensePlate { get; private set; }
        public int VehicleManufactureYear { get; private set; }
        public decimal VehicleFipeValue { get; private set; }
        public decimal ProposalAmount { get; private set; }
        public ProposalStatus Status { get; private set; }

        public static Result<NaturalPersonProposal> Create(
            string customerName,
            string customerCPF,
            DateOnly customerBirthDate,
            string vehicleLicensePlate,
            int vehicleManufactureYear,
            decimal proposalAmount,
            decimal vehicleFipeValue)
        {
            List<ErrorMessage> validationErrors = new List<ErrorMessage>();

            var cpfResult = CPF.Create(customerCPF);
            if (!cpfResult.TryGetValue(out var _cpf, out var cpfErrors))
                validationErrors.AddRange(cpfErrors);

            var placaResult = LicensePlate.Create(vehicleLicensePlate);
            if (!placaResult.TryGetValue(out var _placa, out var placaErrors))
                validationErrors.AddRange(placaErrors);

            if (string.IsNullOrWhiteSpace(customerName))
                validationErrors.Add(ValidationErrors.NaturalPersonProposal.NameIsRequired);

            if (vehicleManufactureYear < 1886 || vehicleManufactureYear > DateTime.Now.AddYears(1).Year)
                validationErrors.Add(ValidationErrors.NaturalPersonProposal.NameIsRequired);

            if (proposalAmount <= 0)
                validationErrors.Add(ValidationErrors.NaturalPersonProposal.AmountValueMustBeGreaterThanZero);

            if (validationErrors.Count > 1)
                return Result<NaturalPersonProposal>.Fail(validationErrors);

            return new NaturalPersonProposal(customerName, _cpf, customerBirthDate, _placa, vehicleManufactureYear, vehicleFipeValue, ProposalStatus.PendingProcessing, proposalAmount);
        }

        public void Processing()
        {
            Status = ProposalStatus.Processing;
        }

        public void Processed()
        {
            Status = ProposalStatus.Processed;
        }
    }
}
