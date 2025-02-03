using RealEstateListing.Application.Interfaces.Repositories;
using RealEstateListing.Application.Interfaces.Services;
using RealEstateListing.Application.Services.Base;
using RealEstateListing.Domain.Entities;

namespace RealEstateListing.Application.Services
{
    public sealed class ListingService(IRepositoryBase<Listing> listingRepository, IUnitOfWork unitOfWork) : IListingService
    {
        public async Task<IEnumerable<Listing>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await listingRepository.GetAllAsync(cancellationToken);
        }

        public async Task<Listing?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await listingRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<ResultService<Listing>> AddAsync(Listing listing, CancellationToken cancellationToken)
        {
            var existingItem = await GetByIdAsync(listing.Id, cancellationToken);

            if (existingItem is not null)
                return ResultService.Fail<Listing>($"A Listing with ID {listing.Id} already exists!");

            await listingRepository.AddAsync(listing, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return ResultService.Ok(listing);
        }

        public async Task<ResultService> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var listing = await GetByIdAsync(id, cancellationToken);

            if (listing is null)
                return ResultService.Fail($"Listing {id} not found!");
            
            await listingRepository.DeleteAsync(listing);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return ResultService.Ok();
        }
    }
}
