using GoBusBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GoBusBookingSystem.DataBase
{
    public class GoBusSystemDbContext : DbContext
    {
        public GoBusSystemDbContext(DbContextOptions<GoBusSystemDbContext> options)
      : base(options)
        {

        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Bus> buses { get; set; }
        public DbSet<Cancellations> cancellations { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Seat> seats { get; set; }

        public DbSet<Trip> trips { get; set; }

        public DbSet<BookingTrip> bookingsTrip { get; set; }
    }
}
