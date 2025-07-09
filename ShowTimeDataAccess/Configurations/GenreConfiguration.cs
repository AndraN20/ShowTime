using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(265);

            builder.HasMany(a => a.Artists)
                .WithMany(g => g.Genres);

            builder.HasData(
                new Genre { Id = 1, Name = "Hip-Hop" },
                new Genre { Id = 2, Name = "Trap" },
                new Genre { Id = 3, Name = "Rock" },
                new Genre { Id = 4, Name = "Pop" }

   );
        }
    }
}
