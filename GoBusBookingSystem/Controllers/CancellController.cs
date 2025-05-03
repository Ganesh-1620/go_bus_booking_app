using GoBusBookingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBusBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancellController : ControllerBase
    {
        private readonly ICancellationService _cancellationService;

        public CancellController(ICancellationService cancellationService)
        {
            _cancellationService = cancellationService;
        }

        [HttpPost("cancel/{bookingId}")]
        public async Task<IActionResult> CancelBooking(int bookingId, [FromQuery] string reason)
        {
            try
            {
                var result = await _cancellationService.CancellDetailsAsync(bookingId, reason);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
