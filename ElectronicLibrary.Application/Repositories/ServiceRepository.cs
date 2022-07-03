using AutoMapper;
using ElectronicLibrary.Application.CQRS.Service.Queries;
using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Domain.Entities;
using ElectronicLibrary.Infrastructure.Extensions;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(ElectronicLibraryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<SelectModel<Guid>>> GetForSelect(GetServicesForSelectQuery request) =>
            await _dbContext.Services.GetForSelect(request.FilterWords).ToListAsync();
    }
}
