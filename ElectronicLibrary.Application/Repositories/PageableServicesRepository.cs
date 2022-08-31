using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Extensions;
using ElectronicBookingSystem.Infrastructure.Models.Service;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Repositories
{
    public class PageableServicesRepository : PageableRepository<GetPageableServicesFilter, Service>, IPageableServicesRepository
    {
        public PageableServicesRepository(ElectronicBookingSystemDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Service> Filter(GetPageableServicesFilter filter) =>
            FilterBySearchTerm(filter.SearchTerm);

        private IQueryable<Service> FilterBySearchTerm(string searchTerm)
        {
            var query = dbSet.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var splitWords = searchTerm.Trim().Split(" ");
                foreach(var word in splitWords)
                {
                    query = query.Where(x => EF.Functions.Like(x.Name, word.ToLikeExpression()) || EF.Functions.Like(x.Description, word.ToLikeExpression()));
                }
            }
            return query;
        }
    }
}
