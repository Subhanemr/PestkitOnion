using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Persistance.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(a => a.Name).IsUnique();
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(6,2)");
            builder.Property(p => p.Description).IsRequired(false).HasColumnType("text");
            builder.Property(p => p.SKU).IsRequired().HasMaxLength(10);

        }
    }
}
