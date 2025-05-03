using GoBusBookingSystem.Models;
using GoBusBookingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBusBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeat(int id)
        {
            var seat = await _seatService.GetSeatByIdAsync(id);
            if (seat == null)
            {
                return NotFound(new { message = "Seat not found" });
            }

            return Ok(seat);
        }

        // GET: api/seats/bus/{busId}
        [HttpGet("bus/{busId}")]
        public async Task<IActionResult> GetSeatsByBus(int busId)
        {
            var seats = await _seatService.GetSeatsByBusIdAsync(busId);
            if (seats == null || !seats.Any())
            {
                return NotFound(new { message = "No seats found for this bus" });
            }

            return Ok(seats);
        }

        // POST: api/seats
        [HttpPost]
        public async Task<IActionResult> CreateSeat([FromBody] Seat seat)
        {
            if (seat == null)
            {
                return BadRequest(new { message = "Invalid seat data" });
            }

            await _seatService.AddSeatAsync(seat);
            return CreatedAtAction(nameof(GetSeat), new { id = seat.SeatId }, seat);
        }

        // PUT: api/seats/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeat(int id, [FromBody] Seat seat)
        {
            if (id != seat.SeatId)
            {
                return BadRequest(new { message = "Seat ID mismatch" });
            }

            var existingSeat = await _seatService.GetSeatByIdAsync(id);
            if (existingSeat == null)
            {
                return NotFound(new { message = "Seat not found" });
            }

            await _seatService.UpdateSeatAsync(seat);
            return NoContent();  // 204 No Content
        }

        // DELETE: api/seats/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            var seat = await _seatService.GetSeatByIdAsync(id);
            if (seat == null)
            {
                return NotFound(new { message = "Seat not found" });
            }

            await _seatService.DeleteSeatAsync(id);
            return NoContent();  // 204 No Content
        }

    }
}
