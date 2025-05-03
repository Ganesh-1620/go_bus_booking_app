using GoBusBookingSystem.Models;

namespace GoBusBookingSystem.Services
{
    public interface ICancellationService
    {
        Task<Cancellations> CancellDetailsAsync(int bookingId, string reason);
    }
}
