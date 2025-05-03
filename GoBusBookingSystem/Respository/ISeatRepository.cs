using GoBusBookingSystem.Models;

namespace GoBusBookingSystem.Respository
{
    public interface ISeatRepository
    {
        Task<Seat> GetSeatByIdAsync(int seatId);
        Task<IEnumerable<Seat>> GetSeatsByBusIdAsync(int busId);
        Task<Seat> AddSeatAsync(Seat seat);
        Task<Seat> UpdateSeatAsync(Seat seat);
        Task<Seat> DeleteSeatAsync(int seatId);
        Task SaveChangesAsync();
    }
}
