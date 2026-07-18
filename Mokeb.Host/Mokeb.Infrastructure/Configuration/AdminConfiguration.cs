using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mokeb.Domain.Model.Entities;
using System;

namespace Mokeb.Infrastructure.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Password)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasData(new Admin(Guid.Parse("00000000-0000-0000-0000-000000000001"), "admin", "admin"));
        }
    }
}
