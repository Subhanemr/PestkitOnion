﻿using PestkitOnion.Domain.Entities;
using System.Linq.Expressions;

namespace PestkitOnion.Application.Abstractions.Repositories
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(bool IsTracking = true,
            bool IsDeleted = false,
            params string[] includes);

        IQueryable<T> GetAllWhere(Expression<Func<T, bool>>? expression = null,
            int skip = 0,
            int take = 0,
            bool IsTracking = true,
            bool IsDeleted = false,
            params string[] includes);

        IQueryable<T> GetAllWhereByOrder(Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>? orderException = null,
            bool IsDescending = false,
            int skip = 0,
            int take = 0,
            bool IsTracking = true,
            bool IsDeleted = false,
            params string[] includes);

        Task<T> GetByIdAsync(int id,
            bool IsTracking = true,
            bool IsDeleted = false,
            params string[] includes);

        Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression,
            bool IsTracking = true,
            bool IsDeleted = false,
            params string[] includes);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SoftDelete(T entity);
        void ReverseSoftDelete(T entity);
        Task SaveChanceAsync();
        Task<bool> CheckUniqueAsync(Expression<Func<T, bool>> expression, bool IsDeleted = false);
    }
}
