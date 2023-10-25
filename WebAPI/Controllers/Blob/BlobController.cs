using Entities.Models.General;
using Entities.Models.Listing;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Blob;
using ServiceLayer.Listing;

namespace WebAPI.Controllers.Blob
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobController : ControllerBase
    {
        private readonly IBlobService _blobService;

        public BlobController(IBlobService blobService, IListingService<PropertyListing> listingService)
        {
            _blobService = blobService ?? throw new ArgumentNullException(nameof(blobService));
        }

        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadFile([FromBody] string filePath, string fileName)
        {
            await _blobService.UploadFileBlobAsync(filePath, fileName);
            return Ok();
        }

        [HttpGet("{blobName}")]
        public async Task<IActionResult> GetBlob(string fileName)
        {
            try
            {
                var blob = await _blobService.GetBlobAsync(fileName);
                return File(blob.Content, blob.ContentType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
