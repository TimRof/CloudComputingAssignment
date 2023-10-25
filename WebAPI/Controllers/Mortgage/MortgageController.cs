using Entities.Models.Listing;
using Entities.Models.Mortgage;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Mortgage;

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

        [HttpGet("{id:guid}")]
        public IActionResult GetMortgageOffer(Guid id)
        {
            // Get a mortgage offer if the token is valid and has not expired
            var mortgageOffer = _mortgageOfferService.Get(id);

            if (mortgageOffer != null && mortgageOffer.ExpiryTime < DateTime.Now)
            {
                return Ok(mortgageOffer);
            }
            else
            {
                return StatusCode(410, "Offer has expired");
            }
        }

    }
}
