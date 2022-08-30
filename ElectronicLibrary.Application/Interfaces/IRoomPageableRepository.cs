using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Interfaces
{
    public interface IRoomPageableRepository : IPageableRepository<GetPageableRoomsFilter, Room>
    {
    }
}
