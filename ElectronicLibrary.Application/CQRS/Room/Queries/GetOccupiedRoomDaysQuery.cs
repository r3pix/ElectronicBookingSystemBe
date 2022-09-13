using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Room.Queries
{
    public class GetOccupiedRoomDaysQuery : IRequest<Response<IEnumerable<DateTime>>>
    {
        public Guid Id { get; set; }
    }
}
