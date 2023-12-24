using PestkitOnion.Application.Dtos.Employee;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface IEmployeeService
    {
        Task<ICollection<ItemEmployeeDto>> GetAllWhereAsync(int page, int take, bool isDeleted = false);
        Task<ICollection<ItemEmployeeDto>> GetAllWhereByOrderAsync(int page, int take, Expression<Func<Employee, object>>? orderExpression, bool isDeleted = false);
        Task<GetEmployeeDto> GetByIdAsync(int id);
        Task CreateAsync(CreateEmployeeDto create);
        Task UpdateAsync(int id, UpdateEmployeeDto update);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task ReverseSoftDeleteAsync(int id);
    }
}
