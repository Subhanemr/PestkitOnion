using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Persistance.Configurations
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Surname).IsRequired().HasMaxLength(50);
            builder.HasIndex(a => a.Name).IsUnique();
            builder.HasIndex(a => a.Surname).IsUnique();
        }
    }
}
