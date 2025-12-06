using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mokeb.Domain.Model.Entities;

namespace Mokeb.Infrastructure.Configuration
{
    public class PublicCommunicationConfig : IEntityTypeConfiguration<PublicCommunication>
    {
        public void Configure(EntityTypeBuilder<PublicCommunication> builder)
        {
            builder.ToTable("PublicCommunications");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.OwnsOne(x => x.IranAddress, a =>
            {
                a.Property(x => x.City)
                    .HasColumnName("Iran_City")
                    .HasMaxLength(100)
                    .IsRequired();

                a.Property(x => x.Area)
                    .HasColumnName("Iran_Area")
                    .HasMaxLength(100)
                    .IsRequired();

                a.Property(x => x.Street)
                    .HasColumnName("Iran_Street")
                    .HasMaxLength(150)
                    .IsRequired();

                a.Property(x => x.Alley)
                    .HasColumnName("Iran_Alley")
                    .HasMaxLength(150)
                    .IsRequired();

                a.Property(x => x.PostalCode)
                    .HasColumnName("Iran_PostalCode")
                    .HasMaxLength(20)
                    .IsRequired();

                a.Property(x => x.LicensePlate)
                    .HasColumnName("Iran_LicensePlate")
                    .IsRequired();

                a.Property(x => x.Floor)
                    .HasColumnName("Iran_Floor")
                    .IsRequired();

                a.Property(x => x.Unit)
                    .HasColumnName("Iran_Unit")
                    .IsRequired();
            });

            builder.OwnsOne(x => x.MokebAddress, a =>
            {
                a.Property(x => x.City)
                    .HasColumnName("Mokeb_City")
                    .HasMaxLength(100)
                    .IsRequired();

                a.Property(x => x.Area)
                    .HasColumnName("Mokeb_Area")
                    .HasMaxLength(100)
                    .IsRequired();

                a.Property(x => x.Street)
                    .HasColumnName("Mokeb_Street")
                    .HasMaxLength(150)
                    .IsRequired();

                a.Property(x => x.Alley)
                    .HasColumnName("Mokeb_Alley")
                    .HasMaxLength(150)
                    .IsRequired();

                a.Property(x => x.PostalCode)
                    .HasColumnName("Mokeb_PostalCode")
                    .HasMaxLength(20)
                    .IsRequired();

                a.Property(x => x.LicensePlate)
                    .HasColumnName("Mokeb_LicensePlate")
                    .IsRequired();

                a.Property(x => x.Floor)
                    .HasColumnName("Mokeb_Floor")
                    .IsRequired();

                a.Property(x => x.Unit)
                    .HasColumnName("Mokeb_Unit")
                    .IsRequired();
            });
        }
    }
}
