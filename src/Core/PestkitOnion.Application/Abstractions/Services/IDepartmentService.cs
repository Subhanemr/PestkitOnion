using PestkitOnion.Application.Dtos.Department;
using PestkitOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface IDepartmentService
    {
        Task<ICollection<ItemDepartmentDto>> GetAllWhereAsync(int page, int take, bool isDeleted = false);
        Task<ICollection<ItemDepartmentDto>> GetAllWhereByOrderAsync(int page, int take, Expression<Func<Department, object>>? orderExpression, bool isDeleted = false);
        Task<GetDepartmentDto> GetByIdAsync(int id);
        Task CreateAsync(CreateDepartmentDto create);
        Task UpdateAsync(int id, UpdateDepartmentDto update);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task ReverseSoftDeleteAsync(int id);
    }
}
