using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Persistance.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(u => u.Surname)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
