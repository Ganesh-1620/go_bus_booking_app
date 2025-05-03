using GoBusBookingSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace GoBusBookingSystem.ModelRequest
{
    
    public class BookingRequestDto
    {
        public List<Booking> Booking { get; set; }
        public int TripId { get; set; }
    }
}
