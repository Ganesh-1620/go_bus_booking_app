using GoBusBookingSystem.Models;

namespace GoBusBookingSystem.Respository
{
    public interface ICustomerRepository
    {
        //customer
        Task<Customer> AddCustomerAsync(Customer customer);
        //Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int customerId);
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<List<Customer>> GetAllCustomersAsync();

        // buses

        Task<Bus> AddBusAsync(Bus bus);
        Task<Bus> GetBusByIdAsync(int busId);
        Task<IEnumerable<Bus>> GetAllBusesAsync();
        Task<bool> DeleteBusAsync(int busId);
    }
}
