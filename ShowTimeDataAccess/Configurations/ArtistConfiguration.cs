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
                         Image = "https://cdn.adh.reperio.news/image-1/1e800e06-0d90-43aa-b8a2-62abb4e3b4dc/index.jpeg?p=f%3Dpng%26w%3D1400%26r%3Dcontain",
                         Genre = "Hip-Hop/Trap" },
                     new Artist { Id = 6,
                         Name = "Justin Timberlake",
                         Image = "https://s-cache.s3.cloudworks.ro/kissfm/cache/1280/0/0/articole/2024/10/08/whatsapp-image-2024-10-08-at-193121_331c8603d9cdc5309b400d2527adf99a.jpeg",
                         Genre = "Pop/R&B" },
                     new Artist {
                         Id = 13,
                         Name = "Subcarpați",
                         Image = "https://timisoara2023.eu/images/8HkvQPwMOnusyl155l1FOQJu-EU=/3465/width-1600%7Cformat-webp/6c62437f-d838-42f3-9bee-8084619d1734",
                         Genre = "Etno/Alternative/Hip-Hop" },
                     new Artist {
                         Id = 12,
                         Name = "Deliric x Silent Strike",
                         Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT8Kgru8ASEuswZMx_U3iE-_T_XQhU_MYGDRQ&s",
                         Genre = "Hip-Hop/Electronic" }
                });
        }
    }
}
