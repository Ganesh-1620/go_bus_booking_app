using GoBusBookingSystem.Models;

namespace GoBusBookingSystem.Respository
{
    public interface IBookingRepository
    {
        Task<List<Booking>> AddBulkBookingsAsync(List<Booking> bookings);
        Task<BookingTrip> CreateTripAsync(BookingTrip trip);
        Task<List<Booking>> CreateBookingAsync(List<Booking> booking, int tripId);
        Task<List<Booking>> GetCompletedReservationsasync();
    }
}
