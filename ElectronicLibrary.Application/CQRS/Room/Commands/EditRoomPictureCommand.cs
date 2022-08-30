using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Room.Commands
{
    public class EditRoomPictureCommand : IRequest
    {
        public Guid RoomId { get; set; }
        public IFormFile File { get; set; }
    }
}
