using PestkitOnion.Application.Dtos.Author;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface IAuthorService
    {
        Task<ICollection<ItemAuthorDto>> GetAllAsync(int page, int take, bool isDeleted = false);
        Task<ICollection<ItemAuthorDto>> GetAllByOrderAsync(int page, int take, Expression<Func<Author, object>>? orderExpression, bool isDeleted = false);
        //Task<GetCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAuthorDto createAuthorDto);
        Task UpdateAsync(int id, UpdateAuthorDto updateAuthorDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);

    }
}
