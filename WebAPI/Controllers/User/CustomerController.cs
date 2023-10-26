using Entities.Models.General;
using Entities.Models.User;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.User;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetCustomers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var customers = await _customerService.GetAllAsync(page, pageSize);
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await _customerService.GetAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Invalid input data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _customerService.AddAsync(customer);

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, null);
        }
    }
}
