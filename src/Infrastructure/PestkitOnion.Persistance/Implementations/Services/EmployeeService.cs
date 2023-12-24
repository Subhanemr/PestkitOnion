using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PestkitOnion.Application.Abstractions.Repositories;
using PestkitOnion.Application.Abstractions.Services;
using PestkitOnion.Application.Dtos.Employee;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Persistance.Implementations.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateEmployeeDto create)
        {
            bool result = await _repository.CheckUniqueAsync(c => c.Name == create.name);
            if (result) throw new Exception("Bad Request");
            await _repository.AddAsync(_mapper.Map<Employee>(create));
            await _repository.SaveChanceAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Employee item = await _repository.GetByIdAsync(id, IsDeleted: true);

            if (item == null) throw new Exception("Not Found");

            _repository.Delete(item);
            await _repository.SaveChanceAsync();
        }

        public async Task<ICollection<ItemEmployeeDto>> GetAllWhereAsync(int page, int take, bool isDeleted = false)
        {
            ICollection<Employee> items = await _repository
                .GetAllWhere(skip: (page - 1) * take, take: take, IsDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemEmployeeDto> dtos = _mapper.Map<ICollection<ItemEmployeeDto>>(items);

            return dtos;
        }
        public async Task<ICollection<ItemEmployeeDto>> GetAllWhereByOrderAsync(int page, int take,
            Expression<Func<Employee, object>>? orderExpression, bool isDeleted = false)
        {
            ICollection<Employee> items = await _repository
                .GetAllWhereByOrder(orderException: orderExpression, skip: (page - 1) * take, take: take, IsDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemEmployeeDto> dtos = _mapper.Map<ICollection<ItemEmployeeDto>>(items);

            return dtos;
        }

        public async Task SoftDeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Employee item = await _repository.GetByIdAsync(id);
            if (item == null) throw new Exception("Not Found");
            _repository.SoftDelete(item);
            await _repository.SaveChanceAsync();
        }
        public async Task ReverseSoftDeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Employee item = await _repository.GetByIdAsync(id);
            if (item == null) throw new Exception("Not Found");
            _repository.ReverseSoftDelete(item);
            await _repository.SaveChanceAsync();
        }

        public async Task UpdateAsync(int id, UpdateEmployeeDto update)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Employee item = await _repository.GetByIdAsync(id);

            if (item == null) throw new Exception("Not Found");

            bool result = await _repository.CheckUniqueAsync(c => c.Name == update.name && c.Id != id);
            if (result) throw new Exception("Bad Request");

            _mapper.Map(update, item);

            _repository.Update(item);
            await _repository.SaveChanceAsync();
        }

        public async Task<GetEmployeeDto> GetByIdAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Employee item = await _repository.GetByIdAsync(id, includes: $"{nameof(Employee.Position)} {nameof(Employee.Department)}");
            if (item == null) throw new Exception("Not Found");

            GetEmployeeDto dto = _mapper.Map<GetEmployeeDto>(item);

            return dto;
        }
    }
}
