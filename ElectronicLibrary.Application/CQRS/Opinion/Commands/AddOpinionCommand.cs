using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Opinion.Commands
{
    public class AddOpinionCommand : IRequest
    {
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public float Grade { get; set; }
        public string Comment { get; set; }
    }
}
