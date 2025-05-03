using GoBusBookingSystem.DataBase;
using GoBusBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GoBusBookingSystem.Respository
{
    public class SeatRepository : ISeatRepository
    {
        private GoBusSystemDbContext _goBusdbContext;

        public SeatRepository(GoBusSystemDbContext dbContext)
        {
            _goBusdbContext = dbContext;
        }

        public async Task<Seat> GetSeatByIdAsync(int seatId)
        {
            return await _goBusdbContext.seats.FindAsync(seatId);
        }

        public async Task<IEnumerable<Seat>> GetSeatsByBusIdAsync(int busId)
        {
            return await _goBusdbContext.seats
                                 .Where(s => s.BusId == busId)
                                 .ToListAsync();
        }

        public async Task<Seat> AddSeatAsync(Seat seat)
        {
            _goBusdbContext.Add(seat);
           await _goBusdbContext.SaveChangesAsync();
            return seat;
        }

        public async Task<Seat> UpdateSeatAsync(Seat seat)
        {
            _goBusdbContext.seats.Update(seat);
            await _goBusdbContext.SaveChangesAsync();
            return seat;

        }

        public async Task<Seat> DeleteSeatAsync(int seatId)
        {
            var seat = await GetSeatByIdAsync(seatId);
            if (seat != null)
            {
                _goBusdbContext.seats.Remove(seat);
                await _goBusdbContext. SaveChangesAsync();
            }
            return seat!;
        }

        public async Task SaveChangesAsync()
        {
            await _goBusdbContext.SaveChangesAsync();
        }
    }
}
