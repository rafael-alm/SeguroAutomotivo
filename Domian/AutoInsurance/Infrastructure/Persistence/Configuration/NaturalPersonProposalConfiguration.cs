using AutoInsurance.Domian.AutoInsurance.Infrastructure.Persistence.Configuration.Converters;
using AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonProposals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoInsurance.Domian.AutoInsurance.Infrastructure.Persistence.Configuration
{
    internal sealed class PropostaPessoaFisicaConfiguration
        : IEntityTypeConfiguration<NaturalPersonProposal>    
    {
        public void Configure(EntityTypeBuilder<NaturalPersonProposal> builder)
        {
            builder.ToTable("NaturalPersonProposal");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CustomerName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.CustomerCPF)
                   .HasConversion<CPFConverter>();
            builder.Property(p => p.CustomerBirthDate)
                   .IsRequired();

            builder.Property(p => p.VehicleLicensePlate)
                   .HasConversion<LicensePlateConverter>();

            builder.Property(p => p.VehicleManufactureYear)
                   .IsRequired();
        }
    }
}
