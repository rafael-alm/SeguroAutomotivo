using AutoInsurance.Domian.AutoInsurance.Infrastructure.Persistence;

namespace AutoInsurance.Common
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
