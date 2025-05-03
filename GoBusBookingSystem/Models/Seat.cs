using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoBusBookingSystem.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }

        [ForeignKey("Bus")]
        public int BusId { get; set; }

        public string SeatNumber { get; set; }
        public bool IsBooked { get; set; } = false;

        //// Foreign Key for Customer who booked this seat, if applicable
       
        //public int? BookedByCustomerId { get; set; }

        //// Foreign Key for Booking that this seat is part of

        //public int? BookId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Booking")]
        public int BookingId { get; set; }

        // Navigation properties for related entities
        //public Bus Bus { get; set; } // if required then add
        //public Customer Customer { get; set; }
        //public Booking Booking { get; set; }
    }
}
