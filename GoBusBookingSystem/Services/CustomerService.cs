using GoBusBookingSystem.Models;
using GoBusBookingSystem.Respository;

namespace GoBusBookingSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            return await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            return await _customerRepository.DeleteCustomerAsync(customerId);
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _customerRepository.GetCustomerByIdAsync(customerId);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        //buses
        public async Task<Bus> AddBusAsync(Bus bus)
        {
            return await _customerRepository.AddBusAsync(bus);
        }

        public async Task<Bus> GetBusByIdAsync(int busId)
        {
            return await _customerRepository.GetBusByIdAsync(busId);
        }

        public async Task<IEnumerable<Bus>> GetAllBusesAsync()
        {
            return await _customerRepository.GetAllBusesAsync();
        }

        public async Task<bool> DeleteBusAsync(int busId)
        {
            return await _customerRepository.DeleteBusAsync(busId);
        }
    }
}
