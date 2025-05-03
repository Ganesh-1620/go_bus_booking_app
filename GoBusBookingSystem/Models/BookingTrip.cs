using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GoBusBookingSystem.Models
{
    public class BookingTrip
    {

        [Key]
        public int TripId { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }

        [Precision(18, 2)]
        public decimal FarePerSeat { get; set; }
    }
}
