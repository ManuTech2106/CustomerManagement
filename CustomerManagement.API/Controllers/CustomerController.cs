using CustomerManagement.Core;
using CustomerManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        /// <summary>
        /// Get all Customers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await customerService.GetCustomers();

            if (result == null)
            {
                var customResponse = new { message = "Customers are not available." };
                return NotFound(customResponse);
            }

            return Ok(result);

        }

        /// <summary>
        /// Get Customer By Customer Id.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var result = await customerService.GetById(id);
            if (result == null)
            {
                var customResponse = new { message = $"No customer Found with the Id: {id}" };
                return NotFound(customResponse);
            }

            return Ok(result);
        }

        /// <summary>
        /// Get customer by certain age.
        /// </summary>
        /// <param name="Age"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Age:int}")]
        public async Task<IActionResult> GetCustomerByAge(int Age)
        {
            var result = await customerService.GetCustomersByAge(Age);
            if (result == null)
            {
                var customResponse = new { message = $"No customer Found with the Age: {Age}" };
                return NotFound(customResponse);
            }

            return Ok(result);
        }

        /// <summary>
        /// Create a new customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try 
            {
                Guid customerId = await customerService.CreateCustomer(customer);

                customer.CustomerId = customerId;
                // Return a 201 Created response with the created resource
                return CreatedAtAction("CreateCustomer", new { customerId = customer.CustomerId }, customer);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Patch a customer.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="customerToUpdate"></param>
        /// <returns></returns>
        [HttpPatch("{customerId}")]
        public async Task PatchCustomer([FromRoute] Guid customerId, [FromBody] JsonPatchDocument customerToUpdate)
        { 
                await customerService.PatchCustomer(customerId, customerToUpdate);
        }
    }
}
