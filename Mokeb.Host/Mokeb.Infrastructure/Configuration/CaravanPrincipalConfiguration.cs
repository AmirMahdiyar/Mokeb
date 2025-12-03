using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mokeb.Domain.Model.Entities;

namespace Mokeb.Infrastructure.Configuration
{
    public class CaravanPrincipalConfiguration : IEntityTypeConfiguration<CaravanPrincipal>
    {
        public void Configure(EntityTypeBuilder<CaravanPrincipal> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever();
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(x => x.FamilyName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(x => x.NationalNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.Gmail)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.EmergencyPhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.Gender)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.PassportNumber)
                .IsRequired();

            builder.Property(x => x.Username)
                .IsRequired();

            builder.Property(x => x.Password)
                .IsRequired();
            builder.OwnsMany(x => x.Pilgrims, pilgrimBuilder =>
            {
                pilgrimBuilder.WithOwner().HasForeignKey("ConvoyPrincipalId");

                pilgrimBuilder.HasKey(p => p.Id);

                pilgrimBuilder.Property(p => p.Name).IsRequired().HasMaxLength(100);
                pilgrimBuilder.Property(p => p.FamilyName).IsRequired().HasMaxLength(100);
                pilgrimBuilder.Property(p => p.NationalNumber).IsRequired().HasMaxLength(10);
                pilgrimBuilder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(11);
                pilgrimBuilder.Property(p => p.PassportNumber).IsRequired().HasMaxLength(20);


                pilgrimBuilder.Property(p => p.Gender)
                    .HasConversion<string>()
                    .IsRequired();

                pilgrimBuilder.Property(p => p.DateOfBirth)
                    .IsRequired();
            });

            builder.HasMany(x => x.Rooms)
                .WithOne()
                .HasForeignKey(x => x.ConvoyPrincipalId);

            builder.HasMany(x => x.Requests)
                .WithOne()
                .HasForeignKey(x => x.ConvoyPrincipalId);

            builder.Property(x => x.ConvoyState)
                .HasConversion<string>();
        }
    }
}
