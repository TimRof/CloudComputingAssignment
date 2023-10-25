using Entities.Models.General;
using Entities.Models.Listing;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Blob;
using ServiceLayer.Listing;

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
            _blobService = blobService;
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
        public IActionResult AddListing([FromBody] PropertyListing listing, string? imagePath)
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

                _blobService.UploadFileBlobAsync(imagePath, imageName + fileExtension);

                listing.ImageName = imageName;
            }
            else
            {
                listing.ImageName = "default.png";
            }

            _listingService.Add(listing);

            return CreatedAtAction(nameof(GetListing), new { id = listing.Id }, null);
        }
    }
}