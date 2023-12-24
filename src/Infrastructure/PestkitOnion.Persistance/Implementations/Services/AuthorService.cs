using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PestkitOnion.Application.Abstractions.Repositories;
using PestkitOnion.Application.Abstractions.Services;
using PestkitOnion.Application.Dtos.Author;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Persistance.Implementations.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateAuthorDto create)
        {
            bool result = await _repository.CheckUniqueAsync(c => c.Name == create.name);
            if (result) throw new Exception("Bad Request");
            await _repository.AddAsync(_mapper.Map<Author>(create));
            await _repository.SaveChanceAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Author item = await _repository.GetByIdAsync(id, IsDeleted:true);

            if (item == null) throw new Exception("Not Found");

            _repository.Delete(item);
            await _repository.SaveChanceAsync();
        }

        public async Task<ICollection<ItemAuthorDto>> GetAllWhereAsync(int page, int take, bool isDeleted = false)
        {
            ICollection<Author> items = await _repository
                .GetAllWhere(skip: (page - 1) * take, take: take, IsDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemAuthorDto> dtos = _mapper.Map<ICollection<ItemAuthorDto>>(items);

            return dtos;
        }
        public async Task<ICollection<ItemAuthorDto>> GetAllWhereByOrderAsync(int page, int take,
            Expression<Func<Author, object>>? orderExpression, bool isDeleted = false)
        {
            ICollection<Author> items = await _repository
                .GetAllWhereByOrder(orderException: orderExpression, skip: (page - 1) * take, take: take, IsDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemAuthorDto> dtos = _mapper.Map<ICollection<ItemAuthorDto>>(items);

            return dtos;
        }

        public async Task SoftDeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Author item = await _repository.GetByIdAsync(id);
            if (item == null) throw new Exception("Not Found");
            _repository.SoftDelete(item);
            await _repository.SaveChanceAsync();
        }
        public async Task ReverseSoftDeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Author item = await _repository.GetByIdAsync(id);
            if (item == null) throw new Exception("Not Found");
            _repository.ReverseSoftDelete(item);
            await _repository.SaveChanceAsync();
        }

        public async Task UpdateAsync(int id, UpdateAuthorDto update)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Author item = await _repository.GetByIdAsync(id);

            if (item == null) throw new Exception("Not Found");

            bool result = await _repository.CheckUniqueAsync(c => c.Name == update.name && c.Id != id);
            if (result) throw new Exception("Bad Request");

            _mapper.Map(update, item);

            _repository.Update(item);
            await _repository.SaveChanceAsync();
        }

        public async Task<GetAuthorDto> GetByIdAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Author item = await _repository.GetByIdAsync(id, includes: nameof(Author.Blogs));
            if (item == null) throw new Exception("Not Found");

            GetAuthorDto dto = _mapper.Map<GetAuthorDto>(item);

            return dto;
        }
    }
}
