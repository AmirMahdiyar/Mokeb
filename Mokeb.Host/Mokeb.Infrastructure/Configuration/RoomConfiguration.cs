using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mokeb.Domain.Model.Entities;

namespace Mokeb.Infrastructure.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Gender)
                   .IsRequired();

            builder.Property(x => x.Capacity)
                   .IsRequired();

            builder.HasMany(x => x.RoomAvailabilities)
                .WithOne()
                .HasForeignKey(x => x.RoomId);
        }
    }
}
