using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Opinion.Queries
{
    public class CheckIsOpinionAllowedQuery : IRequest<Response<bool>>
    {
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
    }
}
