﻿using PestkitOnion.Application.Dtos.Tag;
using PestkitOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface ITagService
    {
        Task<ICollection<ItemTagDto>> GetAllAsync(int page, int take, bool isDeleted = false);
        Task<ICollection<ItemTagDto>> GetAllByOrderAsync(int page, int take, Expression<Func<Tag, object>>? orderExpression, bool isDeleted = false);
        //Task<GetCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateTagDto createTagDto);
        Task UpdateAsync(int id, UpdateTagDto updateTagDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);

    }
}
