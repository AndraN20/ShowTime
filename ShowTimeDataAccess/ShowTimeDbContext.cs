using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Configurations;
using ShowTime.DataAccess.Models;
namespace ShowTime.DataAccess
{
    public class ShowTimeDbContext : DbContext
    {
        public ShowTimeDbContext(DbContextOptions options) : base(options)     { }

        public DbSet<Festival> Festivals { get; set; } = null!;
        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Lineup> Lineups { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new FestivalConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new LineupConfiguration());

        
        }
    }
}



