using ElectronicLibrary.Infrastructure.Extensions;
using ElectronicLibrary.Infrastructure.Models.Room;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.Room.Queries
{
    public class GetRoomListQuery : IRequest<Response<IEnumerable<RoomListModel>>>
    {
    }
}
