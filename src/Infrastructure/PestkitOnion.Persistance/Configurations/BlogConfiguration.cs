using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Persistance.Configurations
{
    internal class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(b=> b.Title).IsRequired().HasMaxLength(100);
            builder.Property(b=> b.Description).IsRequired().HasColumnType("text");
            builder.Property(b=> b.CommentCount).IsRequired();
        }
    }
}
