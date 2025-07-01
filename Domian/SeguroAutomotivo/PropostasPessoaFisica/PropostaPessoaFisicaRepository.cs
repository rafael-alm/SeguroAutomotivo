using SeguroAutomotivo.Common;
using SeguroAutomotivo.Domian.PropostasPessoaFisica.Infrastructure.Persistence;
using SeguroAutomotivo.Domian.SeguroAutomotivo.Aggreates.PropostasPessoaFisica;

namespace SeguroAutomotivo.Domian.SeguroAutomotivo.PropostasPessoaFisica
{
    internal sealed class PropostaPessoaFisicaRepository : BaseRepository<PropostaPessoaFisica>
    {
        public PropostaPessoaFisicaRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task AddAsync(PropostaPessoaFisica entity, CancellationToken cancellationToken) 
        { 
            await context.Set<PropostaPessoaFisica>().AddAsync(entity, cancellationToken);
        }
    }
}
