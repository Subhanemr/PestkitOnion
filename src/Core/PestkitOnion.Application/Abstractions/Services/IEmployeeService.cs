using PestkitOnion.Application.Dtos.Employee;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface IEmployeeService
    {
        Task<ICollection<ItemEmployeeDto>> GetAllAsync(int page, int take, bool isDeleted = false);
        Task<ICollection<ItemEmployeeDto>> GetAllByOrderAsync(int page, int take, Expression<Func<Employee, object>>? orderExpression, bool isDeleted = false);
        //Task<GetCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateEmployeeDto createEmployeeDto);
        Task UpdateAsync(int id, UpdateEmployeeDto updateEmployeeDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);

    }
}
