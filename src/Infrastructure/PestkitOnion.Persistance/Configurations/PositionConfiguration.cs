using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Persistance.Configurations
{
    internal class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(a => a.Name).IsUnique();
        }
    }
}
