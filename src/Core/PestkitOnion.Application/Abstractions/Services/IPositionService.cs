using PestkitOnion.Application.Dtos.Position;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface IPositionService
    {
        Task<ICollection<ItemPositionDto>> GetAllWhereAsync(int page, int take, bool isDeleted = false);
        Task<ICollection<ItemPositionDto>> GetAllWhereByOrderAsync(int page, int take, Expression<Func<Position, object>>? orderExpression, bool isDeleted = false);
        Task<GetPositionDto> GetByIdAsync(int id);
        Task CreateAsync(CreatePositionDto create);
        Task UpdateAsync(int id, UpdatePositionDto update);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task ReverseSoftDeleteAsync(int id);

    }
}
