using Microsoft.EntityFrameworkCore;
using RestaurantReservations.Models;

namespace RestaurantReservations.Services
{
    public class RestaurantReservationDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public RestaurantReservationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>();
            modelBuilder.Entity<Reservation>();
        }
    }
}
