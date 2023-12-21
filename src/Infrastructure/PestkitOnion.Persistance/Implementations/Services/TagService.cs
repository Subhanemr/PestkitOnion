using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PestkitOnion.Application.Abstractions.Repositories;
using PestkitOnion.Application.Abstractions.Services;
using PestkitOnion.Application.Dtos.Tag;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Persistance.Implementations.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateTagDto createTagDto)
        {
            bool result = await _repository.CheckUnique(c => c.Name == createTagDto.name);
            if (result) throw new Exception("Bad Request");
            await _repository.AddAsync(_mapper.Map<Tag>(createTagDto));
            await _repository.SaveChanceAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Tag tag = await _repository.GetByIdAsync(id);

            if (tag == null) throw new Exception("Not Found");

            _repository.Delete(tag);
            await _repository.SaveChanceAsync();
        }

        public async Task<ICollection<ItemTagDto>> GetAllAsync(int page, int take, bool isDeleted = false)
        {
            ICollection<Tag> tags = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, isDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemTagDto> tagDtos = _mapper.Map<ICollection<ItemTagDto>>(tags);

            return tagDtos;
        }
        public async Task<ICollection<ItemTagDto>> GetAllByOrderAsync(int page, int take, Expression<Func<Tag, object>>? orderExpression, bool isDeleted = false)
        {
            ICollection<Tag> tags = await _repository.GetAllByOrderAsync(orderException: orderExpression, skip: (page - 1) * take, take: take, isDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemTagDto> tagDtos = _mapper.Map<ICollection<ItemTagDto>>(tags);

            return tagDtos;
        }

        public async Task SoftDeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag == null) throw new Exception("Not Found");
            _repository.SoftDelete(tag);
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

        public async Task UpdateAsync(int id, UpdateTagDto updateTagDto)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Tag tag = await _repository.GetByIdAsync(id);

            if (tag == null) throw new Exception("Not Found");

            bool result = await _repository.CheckUnique(c => c.Name == updateTagDto.name && c.Id != id);
            if (result) throw new Exception("Bad Request");

            _mapper.Map(updateTagDto, tag);

            _repository.Update(tag);
            await _repository.SaveChanceAsync();
        }
    }
}
