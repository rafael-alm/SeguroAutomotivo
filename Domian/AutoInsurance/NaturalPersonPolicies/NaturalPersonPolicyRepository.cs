using AutoInsurance.Common;
using AutoInsurance.Domian.AutoInsurance.Infrastructure.Persistence;
using AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonProposals;
using Microsoft.EntityFrameworkCore;
using AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonPolicies;

namespace AutoInsurance.Domian.AutoInsurance.AturalPersonProposals
{
    internal sealed class NaturalPersonPolicyRepository : BaseRepository<NaturalPersonPolicy>
    {
        public NaturalPersonPolicyRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task AddAsync(NaturalPersonPolicy entity, CancellationToken cancellationToken)
        {
            await context.Set<NaturalPersonPolicy>().AddAsync(entity, cancellationToken);
        }

        public async Task<NaturalPersonPolicy> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context
                        .Set<NaturalPersonPolicy>()
                        .Where(x => x.Id == id)
                        .FirstAsync(cancellationToken);
        }
    }
}
