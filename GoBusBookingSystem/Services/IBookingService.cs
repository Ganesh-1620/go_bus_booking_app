using GoBusBookingSystem.Models;

namespace GoBusBookingSystem.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> AddBookingAsync(List<Booking> bookingList);
        Task<BookingTrip> AddBookingTripAsync(BookingTrip trip);
        Task<List<Booking>> CreateBookingAsync(List<Booking> bookingList, int tripId);
        Task<byte[]> GenerateReservationsPdfAsync();
    }
}
