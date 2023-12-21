using PestkitOnion.Application.Dtos.Position;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface IPositionService
    {
        Task<ICollection<ItemPositionDto>> GetAllAsync(int page, int take, bool isDeleted = false);
        Task<ICollection<ItemPositionDto>> GetAllByOrderAsync(int page, int take, Expression<Func<Position, object>>? orderExpression, bool isDeleted = false);
        //Task<GetCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreatePositionDto createPositionDto);
        Task UpdateAsync(int id, UpdatePositionDto updatePositionDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);

    }
}
