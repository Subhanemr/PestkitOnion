using PestkitOnion.Application.Abstractions.Repositories;
using PestkitOnion.Domain.Entities;
using PestkitOnion.Persistance.DAL;
using PestkitOnion.Persistance.Implementations.Repositories.Generic;

namespace PestkitOnion.Persistance.Implementations.Repositories
{
    internal class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
    }
}
