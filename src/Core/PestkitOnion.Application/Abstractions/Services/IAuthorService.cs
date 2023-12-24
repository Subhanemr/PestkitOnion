using PestkitOnion.Application.Dtos.Author;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface IAuthorService
    {
        Task<ICollection<ItemAuthorDto>> GetAllWhereAsync(int page, int take, bool isDeleted = false);
        Task<ICollection<ItemAuthorDto>> GetAllWhereByOrderAsync(int page, int take, Expression<Func<Author, object>>? orderExpression, bool isDeleted = false);
        Task<GetAuthorDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAuthorDto create);
        Task UpdateAsync(int id, UpdateAuthorDto update);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task ReverseSoftDeleteAsync(int id);
    }
}
