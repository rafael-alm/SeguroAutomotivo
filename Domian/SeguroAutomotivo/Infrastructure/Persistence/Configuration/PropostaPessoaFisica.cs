using SeguroAutomotivo.Domian.PropostasPessoaFisica.Infrastructure.Persistence.Configuration.Converters;
using SeguroAutomotivo.Domian.SeguroAutomotivo.Aggreates.PropostasPessoaFisica;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeguroAutomotivo.Domian.PropostasPessoaFisica.Infrastructure.Persistence.Configuration
{
    internal sealed class PropostaPessoaFisicaConfiguration
        : IEntityTypeConfiguration<PropostaPessoaFisica>    
    {
        public void Configure(EntityTypeBuilder<PropostaPessoaFisica> builder)
        {
            builder.ToTable("PropostasPessoaFisica");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataCriacao)
                   .IsRequired();

            builder.Property(p => p.NomeCliente)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.CPFCliente)
                   .HasConversion<CPFConverter>();
            builder.Property(p => p.DataNascimentoCliente)
                   .IsRequired();

            builder.Property(p => p.PlacaVeiculo)
                   .HasConversion<PlacaConverter>();

            builder.Property(p => p.AnoFabricacaoVeiculo)
                   .IsRequired();
        }
    }
}
