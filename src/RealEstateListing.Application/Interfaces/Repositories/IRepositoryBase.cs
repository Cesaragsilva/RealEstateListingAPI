using RealEstateListing.Domain.Entities;

namespace RealEstateListing.Application.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(T entity);
    }
}
