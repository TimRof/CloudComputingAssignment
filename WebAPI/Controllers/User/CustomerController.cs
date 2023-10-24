using Entities.Models.General;
using Entities.Models.User;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Listing;
using ServiceLayer.User;

namespace WebAPI.Controllers.User
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
            try
            {
                var customers = _customerService.GetAll(page, pageSize);
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        
        [HttpGet("{id:guid}")]
        public IActionResult GetCustomer(Guid id)
        {
            var customer = _customerService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Invalid input data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _customerService.Add(customer);

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, null);
        }
    }
}
