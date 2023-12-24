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

        public async Task CreateAsync(CreateDepartmentDto create)
        {
            bool result = await _repository.CheckUniqueAsync(c => c.Name == create.name);
            if (result) throw new Exception("Bad Request");
            await _repository.AddAsync(_mapper.Map<Department>(create));
            await _repository.SaveChanceAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Department item = await _repository.GetByIdAsync(id, IsDeleted: true);

            if (item == null) throw new Exception("Not Found");

            _repository.Delete(item);
            await _repository.SaveChanceAsync();
        }

        public async Task<ICollection<ItemDepartmentDto>> GetAllWhereAsync(int page, int take, bool isDeleted = false)
        {
            ICollection<Department> items = await _repository
                .GetAllWhere(skip: (page - 1) * take, take: take, IsDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemDepartmentDto> dtos = _mapper.Map<ICollection<ItemDepartmentDto>>(items);

            return dtos;
        }
        public async Task<ICollection<ItemDepartmentDto>> GetAllWhereByOrderAsync(int page, int take,
            Expression<Func<Department, object>>? orderExpression, bool isDeleted = false)
        {
            ICollection<Department> items = await _repository
                .GetAllWhereByOrder(orderException: orderExpression, skip: (page - 1) * take, take: take, IsDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemDepartmentDto> dtos = _mapper.Map<ICollection<ItemDepartmentDto>>(items);

            return dtos;
        }

        public async Task SoftDeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Department item = await _repository.GetByIdAsync(id);
            if (item == null) throw new Exception("Not Found");
            _repository.SoftDelete(item);
            await _repository.SaveChanceAsync();
        }
        public async Task ReverseSoftDeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Department item = await _repository.GetByIdAsync(id);
            if (item == null) throw new Exception("Not Found");
            _repository.ReverseSoftDelete(item);
            await _repository.SaveChanceAsync();
        }

        public async Task UpdateAsync(int id, UpdateDepartmentDto update)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Department item = await _repository.GetByIdAsync(id);

            if (item == null) throw new Exception("Not Found");

            bool result = await _repository.CheckUniqueAsync(c => c.Name == update.name && c.Id != id);
            if (result) throw new Exception("Bad Request");

            _mapper.Map(update, item);

            _repository.Update(item);
            await _repository.SaveChanceAsync();
        }

        public async Task<GetDepartmentDto> GetByIdAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Department item = await _repository.GetByIdAsync(id, includes: nameof(Department.Employees));
            if (item == null) throw new Exception("Not Found");

            GetDepartmentDto dto = _mapper.Map<GetDepartmentDto>(item);

            return dto;
        }
    }
}
