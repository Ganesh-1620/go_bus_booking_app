using GoBusBookingSystem.Models;
using GoBusBookingSystem.Respository;

namespace GoBusBookingSystem.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatrepository)
        {
            _seatRepository = seatrepository;
        }

        public async Task<Seat> GetSeatByIdAsync(int seatId)
        {
            return await _seatRepository.GetSeatByIdAsync(seatId);
        }

        public async Task<IEnumerable<Seat>> GetSeatsByBusIdAsync(int busId)
        {
            return await _seatRepository.GetSeatsByBusIdAsync(busId);
        }

        public async Task<Seat> AddSeatAsync(Seat seat)
        {
            return await _seatRepository.AddSeatAsync(seat);
        }

        public async Task<Seat> UpdateSeatAsync(Seat seat)
        {
           return await _seatRepository.UpdateSeatAsync(seat);
        }

        public async Task DeleteSeatAsync(int seatId)
        {
            await _seatRepository.DeleteSeatAsync(seatId);
        }
    }
}
