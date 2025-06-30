using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Configurations
{
    public class FestivalConfiguration : IEntityTypeConfiguration<Festival>
    {
        public void Configure(EntityTypeBuilder<Festival> builder)
        {
            builder.ToTable("Festivals");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasMany(x => x.Users)
                .WithMany(u => u.Festivals)
                .UsingEntity<Booking>();

            builder.HasMany(x => x.Artists)
                .WithMany(u => u.Festivals)
                .UsingEntity<Lineup>();

            builder.HasData(new List<Festival>
            {
                new Festival
                {
                     Id = 1,
                Name = "Untold",
                Location = "Cluj-Napoca",
                StartDate = new DateTime(2025, 8, 7),
                EndDate = new DateTime(2025, 8, 10),
                SplashArt = "https://tse1.mm.bing.net/th/id/OIP.7tpAeTwiDDKJu2r-v5h1bwHaE7",
                Capacity = 427000
                }
                ,new Festival
            {
                Id = 2,
                Name = "Electric Castle",
                Location = "Bonțida",
                StartDate = new DateTime(2025, 7, 16),
                EndDate = new DateTime(2025, 7, 20),
                SplashArt = "https://tse4.mm.bing.net/th/id/OIP.PKUQAr-s6irxfdcy6QJ-mAAAAA",
                Capacity = 274000
            },
                new Festival
    {
        Id = 3,
        Name = "Codru Festival",
        Location = "Timișoara (Pădurea Verde)",
        StartDate = new DateTime(2025, 8, 29),
        EndDate = new DateTime(2025, 8, 31),
        SplashArt = "https://www.codrufestival.ro/wp-content/uploads/2024/06/codrufestival-facebook-thumbnail.png",
        Capacity = 30000
    }

            });
        }
    }
}
