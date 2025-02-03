using RealEstateListing.Application.Interfaces.Repositories;
using RealEstateListing.Infrastructure.Data.Context;

namespace RealEstateListing.Infrastructure.Data.Repository
{
    internal class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
