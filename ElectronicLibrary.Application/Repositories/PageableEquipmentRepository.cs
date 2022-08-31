using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Extensions;
using ElectronicBookingSystem.Infrastructure.Models.Equipment;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Repositories
{
    public class PageableEquipmentRepository : PageableRepository<GetPageableEquipmentFilter, Equipment>, IPageableEquipmentRepository 
    {
        public PageableEquipmentRepository(ElectronicBookingSystemDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Equipment> Filter(GetPageableEquipmentFilter filter) =>
            FilterBySearchTerm(filter.SearchTerm);

        private IQueryable<Equipment> FilterBySearchTerm(string searchTerm)
        {
            var query = dbSet.Include(x => x.Files).AsQueryable();
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
