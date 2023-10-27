using Entities.Models.General;
using Entities.Models.Listing;
using Entities.Models.Mortgage;
using Microsoft.AspNetCore.Mvc;
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
    }
}
