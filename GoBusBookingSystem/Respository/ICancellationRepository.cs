using GoBusBookingSystem.Models;

namespace GoBusBookingSystem.Respository
{
    public interface ICancellationRepository
    {
        Task<Cancellations> CancelBookingAsync(int bookingId, string reason);
    }
}
