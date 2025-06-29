using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artists");

            builder.HasKey(a=>a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(265);

            builder.HasMany(a => a.Festivals)
                .WithMany(a => a.Artists)
                .UsingEntity<Lineup>();

        }
    }
}
