using GoBusBookingSystem.Models;

namespace GoBusBookingSystem.Services
{
    public interface ISeatService
    {
        Task<Seat> GetSeatByIdAsync(int seatId);
        Task<IEnumerable<Seat>> GetSeatsByBusIdAsync(int busId);
        Task<Seat> AddSeatAsync(Seat seat);
        Task<Seat> UpdateSeatAsync(Seat seat);
        Task DeleteSeatAsync(int seatId);
    }
}
