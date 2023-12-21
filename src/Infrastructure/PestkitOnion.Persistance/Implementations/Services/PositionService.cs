using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PestkitOnion.Application.Abstractions.Repositories;
using PestkitOnion.Application.Abstractions.Services;
using PestkitOnion.Application.Dtos.Department;
using PestkitOnion.Application.Dtos.Position;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Persistance.Implementations.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _repository;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreatePositionDto createPositionDto)
        {
            bool result = await _repository.CheckUnique(c => c.Name == createPositionDto.name);
            if (result) throw new Exception("Bad Request");
            await _repository.AddAsync(_mapper.Map<Position>(createPositionDto));
            await _repository.SaveChanceAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Position position = await _repository.GetByIdAsync(id);

            if (position == null) throw new Exception("Not Found");

            _repository.Delete(position);
            await _repository.SaveChanceAsync();
        }

        public async Task<ICollection<ItemPositionDto>> GetAllAsync(int page, int take, bool isDeleted = false)
        {
            ICollection<Position> positions = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, isDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemPositionDto> positionDtos = _mapper.Map<ICollection<ItemPositionDto>>(positions);

            return positionDtos;
        }
        public async Task<ICollection<ItemPositionDto>> GetAllByOrderAsync(int page, int take, Expression<Func<Position, object>>? orderExpression, bool isDeleted = false)
        {
            ICollection<Position> positions = await _repository.GetAllByOrderAsync(orderException: orderExpression, skip: (page - 1) * take, take: take, isDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemPositionDto> positionDtos = _mapper.Map<ICollection<ItemPositionDto>>(positions);

            return positionDtos;
        }

        public async Task SoftDeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Position position = await _repository.GetByIdAsync(id);
            if (position == null) throw new Exception("Not Found");
            _repository.SoftDelete(position);
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

        public async Task UpdateAsync(int id, UpdatePositionDto updatePositionDto)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Position position = await _repository.GetByIdAsync(id);

            if (position == null) throw new Exception("Not Found");

            bool result = await _repository.CheckUnique(c => c.Name == updatePositionDto.name && c.Id != id);
            if (result) throw new Exception("Bad Request");

            _mapper.Map(updatePositionDto, position);

            _repository.Update(position);
            await _repository.SaveChanceAsync();
        }
    }
}
