using Microsoft.AspNetCore.Mvc;
using RealEstateListing.Application.Interfaces.Services;
using RealEstateListing.Application.Services.Base;
using RealEstateListing.Domain.Entities;

namespace RealEstateListingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListingsController(IListingService listingService) : ControllerBase
    {

        // Tag this operation as "Listings Retrieval"
        [HttpGet]
        [Tags("Listings Retrieval")]
        [ProducesResponseType(typeof(IEnumerable<Listing>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllListings(CancellationToken cancellationToken)
        {
            var items = await listingService.GetAllAsync(cancellationToken);

            return Ok(items);
        }

        // Tag this operation as "Listings Retrieval"
        [HttpGet("{id}")]
        [Tags("Listings Retrieval")]
        [ProducesResponseType(typeof(Listing), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListingById(string id, CancellationToken cancellationToken)
        {
            var item = await listingService.GetByIdAsync(id, cancellationToken);

            if (item is null)
                return NotFound();

            return Ok(item);
        }

        // Tag this operation as "Listings Management"
        [HttpPost]
        [Tags("Listings Management")]
        [ProducesResponseType(typeof(Listing), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResultService<Listing>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddListing([FromBody] Listing listing, CancellationToken cancellationToken)
        {
            var result = await listingService.AddAsync(listing, cancellationToken);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetListingById), new { id = listing.Id }, listing);
        }

        // Tag this operation as "Listings Management"
        [HttpDelete("{id}")]
        [Tags("Listings Management")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteListing(string id, CancellationToken cancellationToken)
        {
            var result = await listingService.DeleteAsync(id, cancellationToken);

            if(!result.IsSuccess)
                return NotFound();

            return Ok();
        }
    }
}
