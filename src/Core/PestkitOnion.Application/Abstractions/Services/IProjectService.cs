using PestkitOnion.Application.Dtos.Project;
using PestkitOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface IProjectService
    {
        Task<ICollection<ItemProjectDto>> GetAllAsync(int page, int take, bool isDeleted = false);
        Task<ICollection<ItemProjectDto>> GetAllByOrderAsync(int page, int take, Expression<Func<Project, object>>? orderExpression, bool isDeleted = false);
        //Task<GetCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateProjectDto createProjectDto);
        Task UpdateAsync(int id, UpdateProjectDto updateProjectDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);

    }
}
