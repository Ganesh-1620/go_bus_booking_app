using System.ComponentModel.DataAnnotations;

namespace GoBusBookingSystem.Models
{
    public class Bus
    {
        [Key]
        public int BusId { get; set; }
        public string BusServiceNumber { get; set; }
        public string BusType { get; set; }
        public int TotalSeats { get; set; }
        public string RegistrationNumber { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime DepartureTime { get; set; }
        public bool IsActive { get; set; } = false;

        // Navigation property for related seats
        //public List<Seat> Seats { get; set; }
    }
}
