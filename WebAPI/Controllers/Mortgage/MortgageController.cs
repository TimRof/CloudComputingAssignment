using Entities.Models.General;
using Entities.Models.Listing;
using Entities.Models.Mortgage;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Listing;
using ServiceLayer.Mortgage;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class MortgageController : ControllerBase
    {
        private readonly IMortgageApplicationService<MortgageApplication> _mortgageApplicationService;
        private readonly IMortgageOfferService<MortgageOffer> _mortgageOfferService;

        public MortgageController(IMortgageApplicationService<MortgageApplication> mortgageApplicationService, IMortgageOfferService<MortgageOffer> mortgageOfferService)
        {
            _mortgageApplicationService = mortgageApplicationService ?? throw new ArgumentNullException(nameof(mortgageApplicationService));
            _mortgageOfferService = mortgageOfferService ?? throw new ArgumentNullException(nameof(mortgageOfferService));
        }

        [HttpGet("offer/{id:guid}")]
        public async Task<IActionResult> GetMortgageOffer(Guid id)
        {
            // Get a mortgage offer if the token is valid and has not expired
            var mortgageOffer = await _mortgageOfferService.GetAsync(id);

            if (mortgageOffer != null && mortgageOffer.ExpiryTime < DateTime.Now)
            {
                return Ok(mortgageOffer);
            }
            else
            {
                return StatusCode(410, "Offer has expired");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMortgageApplication([FromBody] MortgageApplication mortgageApplication)
        {
            if (mortgageApplication == null)
            {
                return BadRequest("Invalid input data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mortgageApplicationService.AddAsync(mortgageApplication);
            return Ok();
        }

        [HttpPost("status")]
        public async Task<IActionResult> SetApplicationStatusAsync([FromBody] Guid applicationId, ApplicationStatus applicationStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mortgageApplicationService.SetApplicationStatusAsync(applicationId, applicationStatus);
            return Ok();
        }

        [HttpGet("GetMortgageOffersWithStatusReadyToSend")]
        public async Task<IActionResult> GetAllMortgageOffersWithStatusReadyToSendAsync()
        {
            try
            {
                var applications = await _mortgageOfferService.GetAllMortgageOffersWithStatusReadyToSendAsync();
                return Ok(applications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("CalculateAndMakeMortgageOffers")]
        public async Task<IActionResult> CalculateAndMakeMortgageOffersAsync(IEnumerable<MortgageApplication> applications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mortgageOfferService.CalculateAndMakeMortgageOffers(applications);
            return Ok();
        }

        [HttpPost("GetAllMortgageOffersWithStatusReadyToSend")]
        public async Task<IActionResult> GetAllMortgageOffersWithStatusReadyToSendAsync(IEnumerable<MortgageOffer> applications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mortgageOfferService.GetAllMortgageOffersWithStatusReadyToSendAsync();
            return Ok();
        }

        [HttpGet("StartMorningMortgageProcessing")]
        public async Task<IActionResult> StartMorningMortgageProcessing()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mortgageOfferService.StartMorningMortgageProcessing();
            return Ok();
        }

        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            Console.WriteLine("TestTestTestTest");
            return Ok();
        }

        [HttpGet("GetWithStatusProcessing")]
        public async Task<IActionResult> GetAllMortgageApplicationsWithStatusProcessingAsync()
        {
            try
            {
                var applications = await _mortgageApplicationService.GetAllMortgageApplicationsWithStatusProcessingAsync();
                return Ok(applications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
