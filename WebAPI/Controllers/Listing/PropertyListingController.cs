using Entities.Models.General;
using Entities.Models.Listing;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Blob;
using ServiceLayer.Listing;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebAPI.Controllers.Listing
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyListingController : ControllerBase
    {
        private readonly IListingService<PropertyListing> _listingService;
        private readonly IBlobService _blobService;

        public PropertyListingController(IListingService<PropertyListing> listingService, IBlobService blobService)
        {
            _listingService = listingService ?? throw new ArgumentNullException(nameof(listingService));
            _blobService = blobService ?? throw new ArgumentNullException(nameof(blobService));
        }

        [HttpGet]
        public async Task<IActionResult> GetListings([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var listings = await _listingService.GetAllAsync(page, pageSize);
                return Ok(listings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("PriceRange")]
        public async Task<IActionResult> GetListingsByPriceRange([FromQuery] PriceRange priceRange, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var listings = await _listingService.GetAllByPriceRangeAsync(priceRange, page, pageSize);
                return Ok(listings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetListing(Guid id)
        {
            var listing = await _listingService.GetAsync(id);

            if (listing == null)
            {
                return NotFound();
            }

            return Ok(listing);
        }

        [HttpPost]
        public async Task<IActionResult> AddListing([FromBody] PropertyListing listing, string? imagePath)
        {
            if (listing == null)
            {
                return BadRequest("Invalid input data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!String.IsNullOrEmpty(imagePath))
            {
                string imageName = Guid.NewGuid().ToString();
                string fileExtension = Path.GetExtension(imagePath);

                await _blobService.UploadFileBlobAsync(imagePath, imageName + fileExtension);

                listing.ImageName = imageName;
            }
            else
            {
                listing.ImageName = "default.png";
            }

            await _listingService.AddAsync(listing);

            return CreatedAtAction(nameof(GetListing), new { id = listing.Id }, null);
        }
    }
}
