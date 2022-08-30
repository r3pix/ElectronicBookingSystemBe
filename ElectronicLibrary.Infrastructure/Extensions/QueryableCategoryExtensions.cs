using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Extensions
{
    public static class QueryableCategoryExtensions
    {
        public static IQueryable<SelectModel<Guid>> GetForSelect(this IQueryable<Category> query, string filterWords) =>
            query.Filter(filterWords).Select(x => new SelectModel<Guid> { Label = x.Name, Id = x.Id });

        public static IQueryable<Category> Filter(this IQueryable<Category> query, string filterWords)
        {
            if (!string.IsNullOrEmpty(filterWords))
            {
                var filterArray = filterWords.Trim().Split(" ");
                foreach(var word in filterArray)
                {
                    query = query.Where(x => EF.Functions.Like(x.Name,word.ToLikeExpression()));
                }
            }
            return query;
        }
    }
}
