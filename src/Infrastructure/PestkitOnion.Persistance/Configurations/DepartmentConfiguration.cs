using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Persistance.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(a => a.Name).IsUnique();
        }
    }
}
