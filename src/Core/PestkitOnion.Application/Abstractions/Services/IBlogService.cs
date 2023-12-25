using PestkitOnion.Application.Dtos.Blog;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface IBlogService
    {
        Task<ICollection<ItemBlogDto>> GetAllWhereAsync(int page, int take, bool isDeleted = false);
        Task<ICollection<ItemBlogDto>> GetAllWhereByOrderAsync(int page, int take, Expression<Func<Blog, object>>? orderExpression, bool isDeleted = false);
        Task<GetBlogDto> GetByIdAsync(int id);
        Task CreateAsync(CreateBlogDto create);
        Task UpdateAsync(int id, UpdateBlogDto update);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task ReverseSoftDeleteAsync(int id);
    }
}
