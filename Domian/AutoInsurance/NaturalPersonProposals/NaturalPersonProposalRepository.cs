using AutoInsurance.Common;
using AutoInsurance.Domian.AutoInsurance.Infrastructure.Persistence;
using AutoInsurance.Domian.AutoInsurance.Aggreates.NaturalPersonProposals;
using Microsoft.EntityFrameworkCore;

namespace AutoInsurance.Domian.AutoInsurance.AturalPersonProposals
{
    internal sealed class NaturalPersonProposalRepository : BaseRepository<NaturalPersonProposal>
    {
        public NaturalPersonProposalRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task AddAsync(NaturalPersonProposal entity, CancellationToken cancellationToken) 
        { 
            await context.Set<NaturalPersonProposal>().AddAsync(entity, cancellationToken);
        }

        public async Task<NaturalPersonProposal> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context
                        .Set<NaturalPersonProposal>()
                        .Where(x => x.Id == id)
                        .FirstAsync(cancellationToken);
        }
    }
}
