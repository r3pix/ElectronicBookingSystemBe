﻿using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        new Task<IEnumerable<Room>> GetAll(GetMainPageRoomsFilter filter);
    }
}
