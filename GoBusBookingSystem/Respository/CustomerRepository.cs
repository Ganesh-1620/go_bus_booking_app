using GoBusBookingSystem.DataBase;
using GoBusBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GoBusBookingSystem.Respository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly GoBusSystemDbContext _goBusBookingSystem;

        public CustomerRepository(GoBusSystemDbContext goBusBookingSystem)
        {
            _goBusBookingSystem = goBusBookingSystem;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _goBusBookingSystem.customers.Add(customer);
            await _goBusBookingSystem.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var customer = await _goBusBookingSystem.customers.FindAsync(customerId);
            if (customer == null) return false;

            _goBusBookingSystem.customers.Remove(customer);
            await _goBusBookingSystem.SaveChangesAsync();
            return true;
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _goBusBookingSystem.customers.FindAsync(customerId);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _goBusBookingSystem.customers.ToListAsync();
        }


        public async Task<Bus> AddBusAsync(Bus bus)
        {
            _goBusBookingSystem.buses.Add(bus);
            bus.IsActive = true;
            await _goBusBookingSystem.SaveChangesAsync();
            return bus;
        }

        public async Task<Bus> GetBusByIdAsync(int busId)
        {
            return await _goBusBookingSystem.buses.FindAsync(busId);
        }

        public async Task<IEnumerable<Bus>> GetAllBusesAsync()
        {
            return await _goBusBookingSystem.buses.ToListAsync();
        }

        public async Task<bool> DeleteBusAsync(int busId)
        {
            var bus = await _goBusBookingSystem.buses.FindAsync(busId);
            if (bus == null) return false;

            _goBusBookingSystem.buses.Remove(bus);
            await _goBusBookingSystem.SaveChangesAsync();
            return true;
        }
    }
}
