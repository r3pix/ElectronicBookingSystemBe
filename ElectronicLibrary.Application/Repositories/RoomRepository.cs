using AutoMapper;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Extensions;
using ElectronicBookingSystem.Infrastructure.Models.Room;
using ElectronicLibrary.Application.Interfaces;
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
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(ElectronicBookingSystemDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<Room>> GetAll(GetMainPageRoomsFilter filter) =>
           await _dbContext.Rooms
            .Filter(filter.SearchTerm, x => EF.Functions.Like(x.Name, filter.SearchTerm.ToLikeExpression()) || EF.Functions.Like(x.Category.Name, filter.SearchTerm.ToLikeExpression()))
            .Filter(filter.CategoryIds, x=> filter.CategoryIds.Contains(x.CategoryId))
            .Include(x => x.Files).ToListAsync(); //potem filtrowanie dodać
       
    }
}
