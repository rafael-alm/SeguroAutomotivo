using SeguroAutomotivo.Domian.PropostasPessoaFisica.Infrastructure.Persistence;

namespace SeguroAutomotivo.Common
{
    internal abstract class BaseRepository<TAggragate>
        where TAggragate : IAggregate
    {
        protected readonly AppDbContext context;

        protected BaseRepository(AppDbContext appDbContext)
        {
            this.context = appDbContext;
        }
    }
}
