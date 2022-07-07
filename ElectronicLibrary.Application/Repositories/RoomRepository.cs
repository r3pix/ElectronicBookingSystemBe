using AutoMapper;
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
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(ElectronicBookingSystemDbContext dbContext, IMapper mapper): base(dbContext,mapper)
        {
        }

        public override async Task<IEnumerable<Room>> GetAll() =>
           await _dbContext.Rooms.Include(x => x.File).ToListAsync();
       
    }
}
