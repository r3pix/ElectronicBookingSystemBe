using AutoMapper;
using ElectronicLibrary.Application.CQRS.Decoration.Queries;
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
    public class DecorationRepository : Repository<Decoration>, IDecorationRepository
    {
        public DecorationRepository(ElectronicLibraryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<SelectModel<Guid>>> GetForSelect(GetDecorationsForSelectQuery request) =>
           await _dbContext.Decorations.GetForSelect(request.FilterWords).Take(100).ToListAsync();
    }
}
