using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Extensions;
using ElectronicBookingSystem.Infrastructure.Models.Category;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Repositories
{
    public class CategoryPageableRepository : PageableRepository<GetPageableCategoriesFilter, Category>, ICategoryPageableRepository
    {
        public CategoryPageableRepository(ElectronicBookingSystemDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Category> Filter(GetPageableCategoriesFilter filter) =>
            FilterBySearchTerm(filter.SearchTerm);
           
        private IQueryable<Category> FilterBySearchTerm(string searchTerm)
        {
            var query = dbSet.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var splitWords = searchTerm.Trim().Split(" ");
                foreach (var word in splitWords)
                {
                    query = query.Where(x => EF.Functions.Like(x.Name, word.ToLikeExpression()));
                }
            }
            return query;
        }
    }
}
