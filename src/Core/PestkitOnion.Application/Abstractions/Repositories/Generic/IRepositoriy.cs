using PestkitOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PestkitOnion.Application.Abstractions.Repositories
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAllAsync(Expression<Func<T, bool>>? expression = null,
            int skip = 0,
            int take = 0,
            bool IsTracking = true,
            params string[] includes);

        IQueryable<T> GetAllByOrderAsync(Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>? orderException = null,
            bool IsDescending = false,
            int skip = 0,
            int take = 0,
            bool IsTracking = true,
            params string[] includes);

        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChanceAsync();
    }
}
