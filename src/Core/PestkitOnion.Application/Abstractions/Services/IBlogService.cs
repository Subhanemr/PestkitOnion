using PestkitOnion.Application.Dtos.Blog;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface IBlogService
    {
        Task<ICollection<ItemBlogDto>> GetAllAsync(int page, int take, bool isDeleted = false);
        Task<ICollection<ItemBlogDto>> GetAllByOrderAsync(int page, int take, Expression<Func<Blog, object>>? orderExpression, bool isDeleted = false);
        //Task<GetCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateBlogDto createBlogDto);
        Task UpdateAsync(int id, UpdateBlogDto updateBlogDto);
        Task DeleteAsync(int id);
    }
}
