﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PestkitOnion.Application.Abstractions.Repositories;
using PestkitOnion.Application.Abstractions.Services;
using PestkitOnion.Application.Dtos.Position;
using PestkitOnion.Application.Dtos.Product;
using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Persistance.Implementations.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateProductDto create)
        {
            bool result = await _repository.CheckUniqueAsync(c => c.Name == create.name);
            if (result) throw new Exception("Bad Request");
            await _repository.AddAsync(_mapper.Map<Product>(create));
            await _repository.SaveChanceAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Product item = await _repository.GetByIdAsync(id, IsDeleted: true);

            if (item == null) throw new Exception("Not Found");

            _repository.Delete(item);
            await _repository.SaveChanceAsync();
        }

        public async Task<ICollection<ItemProductDto>> GetAllWhereAsync(int page, int take, bool isDeleted = false)
        {
            ICollection<Product> items = await _repository
                .GetAllWhere(skip: (page - 1) * take, take: take, IsDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemProductDto> dtos = _mapper.Map<ICollection<ItemProductDto>>(items);

            return dtos;
        }
        public async Task<ICollection<ItemProductDto>> GetAllWhereByOrderAsync(int page, int take,
            Expression<Func<Product, object>>? orderExpression, bool isDeleted = false)
        {
            ICollection<Product> items = await _repository
                .GetAllWhereByOrder(orderException: orderExpression, skip: (page - 1) * take, take: take, IsDeleted: isDeleted, IsTracking: false).ToListAsync();

            ICollection<ItemProductDto> dtos = _mapper.Map<ICollection<ItemProductDto>>(items);

            return dtos;
        }

        public async Task SoftDeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Product item = await _repository.GetByIdAsync(id);
            if (item == null) throw new Exception("Not Found");
            _repository.SoftDelete(item);
            await _repository.SaveChanceAsync();
        }
        public async Task ReverseSoftDeleteAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Product item = await _repository.GetByIdAsync(id);
            if (item == null) throw new Exception("Not Found");
            _repository.ReverseSoftDelete(item);
            await _repository.SaveChanceAsync();
        }

        public async Task UpdateAsync(int id, UpdateProductDto update)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Product item = await _repository.GetByIdAsync(id);

            if (item == null) throw new Exception("Not Found");

            bool result = await _repository.CheckUniqueAsync(c => c.Name == update.name && c.Id != id);
            if (result) throw new Exception("Bad Request");

            _mapper.Map(update, item);

            _repository.Update(item);
            await _repository.SaveChanceAsync();
        }

        public async Task<GetProductDto> GetByIdAsync(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            Product item = await _repository.GetByIdAsync(id);
            if (item == null) throw new Exception("Not Found");

            GetProductDto dto = _mapper.Map<GetProductDto>(item);

            return dto;
        }
    }
}
