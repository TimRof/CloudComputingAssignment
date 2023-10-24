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

        public MortgageController(IMortgageApplicationService<MortgageApplication> mortgageApplicationService)
        {
            _mortgageApplicationService = mortgageApplicationService ?? throw new ArgumentNullException(nameof(mortgageApplicationService));
        }

    }
}
