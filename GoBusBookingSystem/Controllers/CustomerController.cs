using GoBusBookingSystem.Models;
using GoBusBookingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBusBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest(new { Message = "Customer details are required." });

            try
            {
                var result = await _customerService.AddCustomerAsync(customer);

                if (result != null)
                {
                    return Ok(new { Message = "Customer added successfully.", Data = result });
                }
                else
                {
                    return StatusCode(500, new { Message = "Failed to add customer." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error occurred.", Error = ex.Message });
            }
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var result = await _customerService.DeleteCustomerAsync(id);

                if (result)
                {
                    return Ok(new { Message = "Customer deleted successfully." });
                }
                else
                {
                    return NotFound(new { Message = "Customer not found." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error occurred.", Error = ex.Message });
            }
        }

        [HttpGet("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var result = await _customerService.GetCustomerByIdAsync(id);

                if (result != null)
                {
                    return Ok(new { Data = result });
                }
                else
                {
                    return NotFound(new { Message = "Customer not found." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error occurred.", Error = ex.Message });
            }
        }

       

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var result = await _customerService.GetAllCustomersAsync();

                return Ok(new { Data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error occurred.", Error = ex.Message });
            }
        }

        [HttpPost("AddBus")]
        public async Task<IActionResult> AddBus([FromBody] Bus bus)
        {
            if (bus == null)
            {
                return BadRequest(new { Message = "Bus data is required." });
            }

            try
            {
                var createdBus = await _customerService.AddBusAsync(bus);
                return CreatedAtAction(nameof(GetBusById), new { busId = createdBus.BusId }, new
                {
                    SuccessMessage = "Bus successfully added.",
                    Bus = createdBus
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An error occurred while adding the bus: {ex.Message}" });
            }
        }

        // GET: api/Bus/{id}
        [HttpGet("{busId}")]
        public async Task<IActionResult> GetBusById(int busId)
        {
            if (busId <= 0)
            {
                return BadRequest(new { Message = "Invalid Bus ID provided." });
            }

            var bus = await _customerService.GetBusByIdAsync(busId);
            if (bus == null)
            {
                return NotFound(new { Message = $"Bus with ID {busId} not found." });
            }

            return Ok(new
            {
                SuccessMessage = "Bus successfully retrieved.",
                Bus = bus
            });
        }

        // GET: api/Bus
        [HttpGet]
        public async Task<IActionResult> GetAllBuses()
        {
            var buses = await _customerService.GetAllBusesAsync();
            if (buses == null || !buses.Any())
            {
                return NoContent(); // If no buses are found
            }

            return Ok(new
            {
                SuccessMessage = "Buses successfully retrieved.",
                Buses = buses
            });
        }

        // DELETE: api/Bus/{id}
        [HttpDelete("{busId}")]
        public async Task<IActionResult> DeleteBus(int busId)
        {
            if (busId <= 0)
            {
                return BadRequest(new { Message = "Invalid Bus ID provided." });
            }

            var deleted = await _customerService.DeleteBusAsync(busId);
            if (!deleted)
            {
                return NotFound(new { Message = $"Bus with ID {busId} not found." });
            }

            return NoContent(); // Successfully deleted, no content to return
        }


    }
}
