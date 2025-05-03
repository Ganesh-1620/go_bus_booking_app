using System.ComponentModel.DataAnnotations;

namespace GoBusBookingSystem.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int Age {  get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int UIDNumber { get; set; } = GenerateUIDDigitNumber();

        // Navigation property for related bookings
        //public List<Booking> Bookings { get; set; }

        // Navigation property for related seats
        //public List<Seat> Seats { get; set; }

        private static int GenerateUIDDigitNumber()
        {
            Random random = new Random();
            return random.Next(1000, 10000);
        }
    }
}
