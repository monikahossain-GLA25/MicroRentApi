using Microsoft.EntityFrameworkCore;

namespace MicroRentApi.Data
{
    public class MicroRentDbContext : DbContext
    {
        public MicroRentDbContext(DbContextOptions<MicroRentDbContext> options) : base(options)
        {
        }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Rental> Rentals { get; set; }
        public DbSet<Models.Payment> Payments { get; set; }
        public DbSet<Models.Domain.Destination> Destinations { get; set; }
        public DbSet<Models.Domain.Payment> TrailDifficulties { get; set; }
        public DbSet<Models.Domain.Rental> Trails { get; set; }
    }
}
