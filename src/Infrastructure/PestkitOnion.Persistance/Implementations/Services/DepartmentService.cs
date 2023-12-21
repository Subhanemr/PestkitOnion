using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PestkitOnion.Application.Abstractions.Repositories;
using PestkitOnion.Application.Abstractions.Services;
using PestkitOnion.Application.Dtos.Department;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Persistance.Implementations.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateDepartmentDto createDepartmentDto)
        {
            bool result = await _repository.CheckUnique(c => c.Name == createDepartmentDto.name);
            if (result) throw new Exception("Bad Request");
            await _repository.AddAsync(_mapper.Map<Department>(createDepartmentDto));
            await _repository.SaveChanceAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Department department = await _repository.GetByIdAsync(id);

            if (department == null) throw new Exception("Not Found");

            _repository.Delete(department);
            await _repository.SaveChanceAsync();
        }

        public async Task<ICollection<ItemDepartmentDto>> GetAllAsync(int page, int take, bool isDeleted = false)
        {
            ICollection<Department> departments = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, isDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemDepartmentDto> departmentDtos = _mapper.Map<ICollection<ItemDepartmentDto>>(departments);

            return departmentDtos;
        }
        public async Task<ICollection<ItemDepartmentDto>> GetAllByOrderAsync(int page, int take, Expression<Func<Department, object>>? orderExpression, bool isDeleted = false)
        {
            ICollection<Department> departments = await _repository.GetAllByOrderAsync(orderException: orderExpression, skip: (page - 1) * take, take: take, isDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemDepartmentDto> departmentDtos = _mapper.Map<ICollection<ItemDepartmentDto>>(departments);

            return departmentDtos;
        }

        public async Task SoftDeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Department department = await _repository.GetByIdAsync(id);
            if (department == null) throw new Exception("Not Found");
            _repository.SoftDelete(department);
            await _repository.SaveChanceAsync();
        }

        //public async Task<GetCategoryDto> GetByIdAsync(int id)
        //{
        //    Category category = await _repository.GetByIdAsync(id);
        //    if (category == null) throw new Exception("Not Found");

        //    return new GetCategoryDto
        //    {
        //        Id = category.Id,
        //        Name = category.Name
        //    };
        //}

        public async Task UpdateAsync(int id, UpdateDepartmentDto updateDepartmentDto)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Department department = await _repository.GetByIdAsync(id);

            if (department == null) throw new Exception("Not Found");

            bool result = await _repository.CheckUnique(c => c.Name == updateDepartmentDto.name && c.Id != id);
            if (result) throw new Exception("Bad Request");

            _mapper.Map(updateDepartmentDto, department);

            _repository.Update(department);
            await _repository.SaveChanceAsync();
        }
    }
}
