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
        Task<ICollection<ItemDepartmentDto>> GetAllAsync(int page, int take, bool isDeleted = false);
        Task<ICollection<ItemDepartmentDto>> GetAllByOrderAsync(int page, int take, Expression<Func<Department, object>>? orderExpression, bool isDeleted = false);
        //Task<GetCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateDepartmentDto createDepartmentDto);
        Task UpdateAsync(int id, UpdateDepartmentDto createDepartmentDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);

    }
}
