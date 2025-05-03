using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GoBusBookingSystem.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Seat")]
        public int SeatId { get; set; }
        public DateTime BookingDate { get; set; }

        [Precision(18, 2)]
        public decimal TotalAmount { get; set; }

        public string PaymentStatus { get; set; }
        public string BookingStatus { get; set; } = "Booked";

        public string? FromPlace { get; set; }
        public string? ToPlace { get; set; }

        public string? PickUppoint { get; set; }

        public string? PickUppointAddress { get; set; }

        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalOn { get; set; }

        

        public string TicketNumber { get; set; } = GenerateTicketNumber();


        // Navigation properties for related entities
       

        public List<string> SeatNumber { get; set; }


        private static string GenerateTicketNumber()
        {
            Random random = new Random();
            int number = random.Next(100000, 999999); // 6-digit random number
            return $"TKT{number}";
        }
    }
}
