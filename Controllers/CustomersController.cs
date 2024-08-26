using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkDemo.IServices;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerList()
        {
            var customerList = await _customerService.GetAllCustomer();
            if (customerList == null) { return NotFound(); }
            return Ok(customerList);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var customer = await _customerService.GetCustomerById(customerId);
            if (customer == null) { return NotFound(); };
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerDetail customer)
        {
            var isCustomerCreated = await _customerService.CreateCustomer(customer);
            if (isCustomerCreated)
            {
                return Ok(isCustomerCreated);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerDetail customer)
        {
            var isCustomerUpdated = await _customerService.UpdateCustomer(customer);
            if (isCustomerUpdated)
            {
                return Ok(isCustomerUpdated);
            }
            return BadRequest();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var isCustomerDeleted = await _customerService.DeleteCustomer(customerId);
            if (isCustomerDeleted)
            {
                return Ok(isCustomerDeleted);
            }
            return BadRequest();
        }
    }
}
