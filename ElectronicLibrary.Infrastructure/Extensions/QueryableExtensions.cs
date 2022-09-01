using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DynamicLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public async static Task<(IEnumerable<TEntity>, int)> Page<TEntity>(this IQueryable<TEntity> query, IPageableQueryModel page) where TEntity : BaseEntity
        {
            var count = await query.CountAsync();
            if (page.Desc)
            {
                query = query.OrderBy(page.OrderBy + " desc");
            }
            else
            {
                query = query.OrderBy(page.OrderBy + " asc");
            }
            query = query.Skip((page.PageNumber - 1) * page.PageSize);
            query = query.Take(page.PageSize);
            return (await query.ToListAsync(), count);
        }

        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> query, string element, Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity
        {
            if (!string.IsNullOrEmpty(element))
            {
                query = query.Where(predicate);
            }
            return query;
        }

        public static IQueryable<TEntity> Filter<TEntity, T>(this IQueryable<TEntity> query, List<T> element, Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity
        {
            if(element !=null && element?.Count > 0)
            {
                query = query.Where(predicate);
            }
            return query;
        }
    }
}
