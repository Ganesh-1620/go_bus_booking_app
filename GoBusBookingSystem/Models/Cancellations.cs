using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GoBusBookingSystem.Models
{
    public class Cancellations
    {
        [Key]
        public int CancellationId { get; set; }

        [ForeignKey("Booking")]
        public int BookingId { get; set; }

        public DateTime CancellationDate { get; set; }
        public string? CancellationReason { get; set; }
        [Precision(18, 2)]
        public decimal RefundAmount { get; set; }
        public string? Status { get; set; }

        // Navigation properties for related entities
       // public Booking Booking { get; set; }
    }
}
