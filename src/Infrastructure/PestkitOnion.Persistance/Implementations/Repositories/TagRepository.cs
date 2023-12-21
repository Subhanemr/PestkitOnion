using PestkitOnion.Application.Abstractions.Repositories;
using PestkitOnion.Domain.Entities;
using PestkitOnion.Persistance.DAL;
using PestkitOnion.Persistance.Implementations.Repositories.Generic;

namespace PestkitOnion.Persistance.Implementations.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context) { }
    }
}
