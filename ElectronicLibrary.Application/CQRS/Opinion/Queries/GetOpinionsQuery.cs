using ElectronicBookingSystem.Infrastructure.Models.Opinion;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Opinion.Queries
{
    public class GetOpinionsQuery : IRequest<Response<IEnumerable<OpinionModel>>>
    {
        public Guid RoomId { get; set; }
    }
}
