using Microsoft.AspNetCore.Mvc;
using Models.General;
using Models.Listings;
using Models.Users;
using ServiceLayer.Listings;
using ServiceLayer.Users;

namespace WebAPI.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService<Customer> _customerService;

        public CustomerController(ICustomerService<Customer> customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpGet]
        public IActionResult GetCustomers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return null;
        }
        
        [HttpGet("{id:guid}")]
        public IActionResult GetCustomer(Guid id)
        {
            return null;
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            return null;
        }
    }
}
