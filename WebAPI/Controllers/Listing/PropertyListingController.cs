using Entities.Models.General;
using Entities.Models.Listing;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Listing;

namespace WebAPI.Controllers.Listing
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyListingController : ControllerBase
    {
        private readonly IListingService<PropertyListing> _listingService;

        public PropertyListingController(IListingService<PropertyListing> listingService)
        {
            _listingService = listingService ?? throw new ArgumentNullException(nameof(listingService));
        }

        [HttpGet]
        public IActionResult GetListings([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var listings = _listingService.GetAll(page, pageSize);
                return Ok(listings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("PriceRange")]
        public IActionResult GetListingsByPriceRange([FromQuery] PriceRange priceRange, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var listings = _listingService.GetAllByPriceRange(priceRange, page, pageSize);
                return Ok(listings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetListing(Guid id)
        {
            var listing = _listingService.Get(id);

            if (listing == null)
            {
                return NotFound();
            }

            return Ok(listing);
        }

        [HttpPost]
        public IActionResult AddListing([FromBody] PropertyListing listing)
        {
            if (listing == null)
            {
                return BadRequest("Invalid input data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _listingService.Add(listing);

            return CreatedAtAction(nameof(GetListing), new { id = listing.Id }, null);
        }

        // add images to listing and save to blob storage


    }
}