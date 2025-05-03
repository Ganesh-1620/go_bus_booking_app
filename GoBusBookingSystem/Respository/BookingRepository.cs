using GoBusBookingSystem.DataBase;
using GoBusBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GoBusBookingSystem.Respository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly GoBusSystemDbContext _goBusSystemDbContext;

        public BookingRepository(GoBusSystemDbContext goBusSystemDbContext)
        {
            _goBusSystemDbContext = goBusSystemDbContext;
        }

        public async Task<List<Booking>> AddBulkBookingsAsync(List<Booking> bookings)
        {
            foreach (var item in bookings)
            {
                item.BookingStatus = "Booked";
            }
            _goBusSystemDbContext.Bookings.AddRange(bookings);
            await _goBusSystemDbContext.SaveChangesAsync();
            return bookings;
        }

        public async Task<BookingTrip> CreateTripAsync(BookingTrip trip)
        {
            _goBusSystemDbContext.bookingsTrip.Add(trip);
            await _goBusSystemDbContext.SaveChangesAsync();
            return trip;
        }


        public async Task<List<Booking>> CreateBookingAsync(List<Booking> booking,  int tripId)
        {
            var trip = await _goBusSystemDbContext.bookingsTrip.FindAsync(tripId);
            if (trip == null)
                throw new Exception("Trip not found.");

           // int seatCount = booking.SeatNumbers.Count;

            foreach (var item in booking)
            {
                int seatCount = item.SeatNumber?.Count ?? 0;
                item.TotalAmount = trip.FarePerSeat * seatCount;
                item.BookingStatus = "Booked";
            }
           
            _goBusSystemDbContext.Bookings.AddRange(booking);
            await _goBusSystemDbContext.SaveChangesAsync();


            // Save associated seats for each booking
            foreach (var list in booking)
            {
                foreach (var seat in list.SeatNumber)
                {
                    _goBusSystemDbContext.seats.Add(new Seat
                    {
                        BookingId = booking.First().BookingId,
                        SeatNumber = seat
                    });
                }
            }


            await _goBusSystemDbContext.SaveChangesAsync();

            return booking;
        }

        public async Task<List<Booking>> GetCompletedReservationsasync()
        {
            var query = _goBusSystemDbContext.Bookings.AsNoTracking()
                          .Where(x => x.BookingStatus.Equals("Booked"));
            return await query.ToListAsync();
        }


    }
}
