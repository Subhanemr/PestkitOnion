﻿using Microsoft.EntityFrameworkCore;
using PestkitOnion.Domain.Entities;
using System.Drawing;
using System.Reflection;

namespace PestkitOnion.Persistance.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Tag>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Department>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Project>().HasQueryFilter(c => c.IsDeleted == false);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in entities)
            {
                switch (data.State)
                {
                    case EntityState.Modified:
                        data.Entity.CreateAt = DateTime.Now;
                        break;
                    case EntityState.Added:
                        data.Entity.UpdateAt = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
