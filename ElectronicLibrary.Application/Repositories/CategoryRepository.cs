using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Category.Queries;
using ElectronicBookingSystem.Infrastructure.Extensions;
using ElectronicLibrary.Application.Repositories;
using ElectronicLibrary.Infrastructure.Extensions;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicBookingSystem.Application.Interfaces;

namespace ElectronicBookingSystem.Application.Repositories
{
    public class CategoryRepository : Repository<Domain.Entities.Category>, ICategoryRepository
    {
        public CategoryRepository(ElectronicBookingSystemDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<SelectModel<Guid>>> GetForSelect(GetCategoriesForSelectQuery query) =>
            await _dbContext.Categories.GetForSelect(query.FilterWords).Take(100).ToListAsync();
    }
}
