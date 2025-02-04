using Microsoft.EntityFrameworkCore;
using RealEstateListing.Application.Interfaces.Repositories;
using RealEstateListing.Domain.Entities;
using RealEstateListing.Infrastructure.Data.Context;

namespace RealEstateListing.Infrastructure.Data.Repository
{
    internal class RepositoryBase<T>(ApplicationDbContext dbContext) : IRepositoryBase<T> where T : BaseEntity
    {
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await dbContext.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await dbContext.Set<T>().AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await dbContext.Set<T>().AddAsync(entity, cancellationToken);
            
            return entity;
        }

        public Task DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
