using PestkitOnion.Application.Dtos.Product;
using PestkitOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PestkitOnion.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<ICollection<ItemProductDto>> GetAllAsync(int page, int take, bool isDeleted = false);
        Task<ICollection<ItemProductDto>> GetAllByOrderAsync(int page, int take, Expression<Func<Product, object>>? orderExpression, bool isDeleted = false);
        //Task<GetCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateProductDto createProductDto);
        Task UpdateAsync(int id, UpdateProductDto updateProductDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);

    }
}
