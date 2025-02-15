using RealEstateListing.Application.Services.Base;
using RealEstateListing.Domain.Entities;

namespace RealEstateListing.Application.Interfaces.Services
{
    public interface IListingService
    {
        Task<Listing?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Listing>> GetAllAsync(CancellationToken cancellationToken);
        Task<ResultService<Listing>> AddAsync(Listing listing, CancellationToken cancellationToken);
        Task<ResultService> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
