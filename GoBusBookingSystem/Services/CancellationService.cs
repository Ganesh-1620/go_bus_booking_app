using GoBusBookingSystem.Models;
using GoBusBookingSystem.Respository;

namespace GoBusBookingSystem.Services
{
    public class CancellationService : ICancellationService
    {
        private readonly ICancellationRepository _cancellationRepository;

        public CancellationService(ICancellationRepository cancellationRepository)
        {
           _cancellationRepository = cancellationRepository;
        }

        public async Task<Cancellations> CancellDetailsAsync(int bookingId, string reason)
        {
            return await _cancellationRepository.CancelBookingAsync(bookingId, reason);
        }
    }
}
