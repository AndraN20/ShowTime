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

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(265);

            builder.HasMany(a => a.Festivals)
                .WithMany(a => a.Artists)
                .UsingEntity<Lineup>();

            builder.HasData(
                new List<Artist>
                {
                     new Artist { Id = 4,
                         Name = "Metro Boomin",
                         Image = "https://untold-universe-public-resources-prod.s3.eu-west-1.amazonaws.com/metroboomin.png",
                         Genre = "Hip-Hop/Trap" },
                     new Artist { Id = 6,
                         Name = "Justin Timberlake",
                         Image = "https://electriccastle-assets.s3.amazonaws.com/justin_timberlake.png",
                         Genre = "Pop/R&B" },
                     new Artist {
                         Id = 13,
                         Name = "Subcarpați",
                         Image = "https://subcarpati.com/img/logo.jpg",
                         Genre = "Etno/Alternative/Hip-Hop" },
                     new Artist {
                         Id = 12,
                         Name = "Deliric x Silent Strike",
                         Image = "https://codru-festival.com/img/deliricsilentstrike.png",
                         Genre = "Hip-Hop/Electronic" }
                });
        }
    }
}
