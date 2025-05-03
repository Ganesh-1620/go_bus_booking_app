using GoBusBookingSystem.ModelRequest;
using GoBusBookingSystem.Models;
using GoBusBookingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBusBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("Booking")]
        public async Task<IActionResult> InsertBooking([FromBody] List<Booking> booking)
        {
            if (booking == null)
                return BadRequest(new { Message = "Booking details are required." });

            try
            {
                var result = await _bookingService.AddBookingAsync(booking);

                if (result != null)
                {
                    return Ok(new { Message = "Booking added successfully.", Data = result });
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

        [HttpPost("Addtrip")]
        public async Task<IActionResult> AddTrip([FromBody] BookingTrip trip)
        {
            if (trip == null)
                return BadRequest(new { Message = "trip details are required." });

            try
            {
                var result = await _bookingService.AddBookingTripAsync(trip);

                if (result != null)
                {
                    return Ok(new { Message = "Trip added successfully.", Data = result });
                }
                else
                {
                    return StatusCode(500, new { Message = "Failed to trip details." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error occurred.", Error = ex.Message });
            }
        }


        [HttpPost("SaveCustomerBooking")]
        public async Task<IActionResult> CreateCustomer([FromBody] BookingRequestDto booking)
        {
            if (booking == null)
                return BadRequest(new { Message = "Booking details are required." });

            try
            {
                var result = await _bookingService.CreateBookingAsync(booking.Booking, booking.TripId);

                if (result != null)
                {
                    return Ok(new { Message = "Booking added successfully.", Data = result });
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


        [HttpGet("GenerateReservationsPdf")]
        public async Task<IActionResult> GenerateReservationsPdfAsync()
        {
            try
            {
                var pdfBytes = await _bookingService.GenerateReservationsPdfAsync(); // or _reservationRepository

                if (pdfBytes == null || pdfBytes.Length == 0)
                {
                    return NotFound(new { Message = "No reservations found or failed to generate PDF." });
                }

                return File(pdfBytes, "application/pdf", "ReservationsReport.pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while generating the PDF.",
                    Error = ex.Message
                });
            }
        }


    }

}
