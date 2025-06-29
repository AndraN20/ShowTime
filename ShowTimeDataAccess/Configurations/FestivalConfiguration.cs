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
        }
    }
}
