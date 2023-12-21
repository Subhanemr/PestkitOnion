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

        public async Task CreateAsync(CreateAuthorDto createAuthorDto)
        {
            bool result = await _repository.CheckUnique(c => c.Name == createAuthorDto.name && c.Surname == createAuthorDto.surname);
            if (result) throw new Exception("Bad Request");
            await _repository.AddAsync(_mapper.Map<Author>(createAuthorDto));
            await _repository.SaveChanceAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Author author = await _repository.GetByIdAsync(id);

            if (author == null) throw new Exception("Not Found");

            _repository.Delete(author);
            await _repository.SaveChanceAsync();
        }

        public async Task<ICollection<ItemAuthorDto>> GetAllAsync(int page, int take, bool isDeleted = false)
        {
            ICollection<Author> authors = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, isDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemAuthorDto> authorDtos = _mapper.Map<ICollection<ItemAuthorDto>>(authors);

            return authorDtos;
        }
        public async Task<ICollection<ItemAuthorDto>> GetAllByOrderAsync(int page, int take, Expression<Func<Author, object>>? orderExpression, bool isDeleted = false)
        {
            ICollection<Author> authors = await _repository.GetAllByOrderAsync(orderException: orderExpression, skip: (page - 1) * take, take: take, isDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemAuthorDto> authorDtos = _mapper.Map<ICollection<ItemAuthorDto>>(authors);

            return authorDtos;
        }

        public async Task SoftDeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Author author = await _repository.GetByIdAsync(id);
            if (author == null) throw new Exception("Not Found");
            _repository.SoftDelete(author);
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

        public async Task UpdateAsync(int id, UpdateAuthorDto updateAuthorDto)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Author author = await _repository.GetByIdAsync(id);

            if (author == null) throw new Exception("Not Found");

            bool result = await _repository.CheckUnique(c => c.Name == updateAuthorDto.name && c.Surname == updateAuthorDto.surname && c.Id != id);
            if (result) throw new Exception("Bad Request");

            _mapper.Map(updateAuthorDto, author);

            _repository.Update(author);
            await _repository.SaveChanceAsync();
        }
    }
}
