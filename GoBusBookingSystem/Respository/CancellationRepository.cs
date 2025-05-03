using GoBusBookingSystem.DataBase;
using GoBusBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GoBusBookingSystem.Respository
{
    public class CancellationRepository :ICancellationRepository
    {
        private readonly GoBusSystemDbContext _goBusSystemDbContext;

        public CancellationRepository(GoBusSystemDbContext goBusSystemDbContext)
        {
            _goBusSystemDbContext = goBusSystemDbContext;
        }

        public async Task<Cancellations> CancelBookingAsync(int bookingId, string reason)
        {
            var booking = await _goBusSystemDbContext.Bookings.FindAsync(bookingId);

            if (booking == null)
                throw new Exception("Booking not found.");

            var daysDifference = (booking.DepartureDateTime.Date - DateTime.UtcNow.Date).TotalDays;
            decimal refundAmount = 0;

            if (daysDifference >= 7)
            {
                refundAmount = booking.TotalAmount;
            }
            else if (daysDifference <= 0)
            {
                refundAmount = booking.TotalAmount * 0.2M;
            }

            var cancellation = new Cancellations
            {
                BookingId = bookingId,
                CancellationDate = DateTime.UtcNow,
                CancellationReason = reason,
                RefundAmount = refundAmount,
                Status = "Cancelled"
            };

            booking.BookingStatus = "Cancelled";
            _goBusSystemDbContext.cancellations.Add(cancellation);
            await _goBusSystemDbContext.SaveChangesAsync();

            return cancellation;
        }
    }
}
