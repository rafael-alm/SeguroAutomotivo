using AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonProposals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonPolicies;

namespace AutoInsurance.Domian.AutoInsurance.Infrastructure.Persistence.Configuration
{
    internal sealed class NaturalPersonPolicyConfiguration
        : IEntityTypeConfiguration<NaturalPersonPolicy>
    {
        public void Configure(EntityTypeBuilder<NaturalPersonPolicy> builder)
        {
            builder.ToTable("NaturalPersonPolicy");
            builder.HasKey(p => p.Id);

            builder.HasOne<NaturalPersonProposal>()
                   .WithMany()
                   .HasForeignKey(p => p.NaturalPersonProposalId);

            builder.Property(x => x.Number)
                   .UseIdentityColumn()
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.StartCoverageDate)
                   .IsRequired();

            builder.Property(p => p.Amount)
                   .IsRequired();

            builder.Property(p => p.IssueDate)
                   .IsRequired();

            builder.Property(p => p.CreatedAt)
                   .IsRequired();

            builder.Property(p => p.UpdatedAt)
                   .IsRequired();

            builder.Property(p => p.EndCoverageDate)
                   .IsRequired();
        }
    }
}
