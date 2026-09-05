using Microsoft.EntityFrameworkCore;

namespace MicroRentApi.Data
{
    public class MicroRentDbContext : DbContext
    {
        public MicroRentDbContext(DbContextOptions<MicroRentDbContext> options) : base(options)
        {

        }

        public DbSet<Models.Domain.Rental> Rentals { get; set; }
        public DbSet<Models.Domain.User> Users { get; set; }
        public DbSet<Models.Domain.Payment> Payments { get; set; }

    }
}
