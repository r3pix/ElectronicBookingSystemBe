using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Extensions;
using ElectronicBookingSystem.Infrastructure.Models.Decoration;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Repositories
{
    public class PageableDecorationsRepository : PageableRepository<GetPageableDecorationsFilter, Decoration>, IPageableDecorationsRepository
    {
        public PageableDecorationsRepository(ElectronicBookingSystemDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Decoration> Filter(GetPageableDecorationsFilter filter) =>
            FilterBySearchTerm(filter.SearchTerm);
        

        private IQueryable<Decoration> FilterBySearchTerm(string searchTerm)
        {
            var query = dbSet.Include(x=>x.Files).AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var splitWords = searchTerm.Trim().Split(" ");
                foreach(var word in splitWords)
                {
                    query = query.Where(x => EF.Functions.Like(x.Name, word.ToLikeExpression()));
                }
            }
            return query;
        }
    }
}
