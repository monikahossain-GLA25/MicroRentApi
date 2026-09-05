using Microsoft.EntityFrameworkCore;
using MicroRentApi.Models.Domain;

namespace MicroRentApi.Data
{
    public class MicroRentDbContext : DbContext
    {
        public MicroRentDbContext(
            DbContextOptions<MicroRentDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}