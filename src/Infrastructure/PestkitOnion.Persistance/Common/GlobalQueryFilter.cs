using Microsoft.EntityFrameworkCore;
using PestkitOnion.Domain.Entities;

namespace PestkitOnion.Persistance.Common
{
    internal static class GlobalQueryFilter
    {
        public static void ApplyQuery<T>(ModelBuilder modelBuilder) where T : BaseEntity, new()
        {
            modelBuilder.Entity<T>().HasQueryFilter(c => c.IsDeleted == false);
        }

        public static void ApplyQueryFilter(this ModelBuilder modelBuilder)
        {
            ApplyQuery<Department>(modelBuilder);
            ApplyQuery<Product>(modelBuilder);
            ApplyQuery<Tag>(modelBuilder);
            ApplyQuery<Author>(modelBuilder);
            ApplyQuery<Position>(modelBuilder);
        }
    }
}
