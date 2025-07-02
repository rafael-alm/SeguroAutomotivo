using AutoInsurance.Common;
using AutoInsurance.Crosscutting;

namespace AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonPolicies
{
    public sealed class NaturalPersonPolicy: Entity, IAggregate
    {
        private NaturalPersonPolicy() { }

        private NaturalPersonPolicy(DateTime issueDate, decimal amount, DateOnly startCoverageDate, DateOnly endCoverageDate, Guid naturalPersonProposalId)
        {
            IssueDate = issueDate;
            Amount = amount;
            StartCoverageDate = startCoverageDate;
            EndCoverageDate = endCoverageDate;
            NaturalPersonProposalId = naturalPersonProposalId;
        }

        public int Number { get; private set; } 
        public DateTime IssueDate { get; private set; }
        public decimal Amount { get; private set; }
        public DateOnly StartCoverageDate { get; private set; }
        public DateOnly EndCoverageDate { get; private set; }
        public Guid NaturalPersonProposalId { get; private set; }

        public static Result<NaturalPersonPolicy> Create(Guid NaturalPersonProposalId, decimal amount)
        {
            if (amount <= 0)
                return Result<NaturalPersonPolicy>.Fail(ValidationErrors.NaturalPersonPolicy.AmountValueMustBeGreaterThanZero);

            var today = DateTime.Today;
            var todayDateOnly = DateOnly.FromDateTime(today);

            return new NaturalPersonPolicy(today, amount, todayDateOnly, todayDateOnly.AddYears(1), NaturalPersonProposalId);
        }
    }
}
