using AutoMapper;
using ElectronicLibrary.Domain.Entities;
using ElectronicLibrary.Infrastructure.Extensions;
using ElectronicLibrary.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Repositories
{
    public class RoomRepository : Repository<Room>
    {
        public RoomRepository(ElectronicLibraryDbContext dbContext, IMapper mapper): base(dbContext,mapper)
        {
        }

        
    }
}
