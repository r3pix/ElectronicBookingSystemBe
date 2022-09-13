using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Extensions;
using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Room.Queries
{
    public class GetOccupiedRoomDaysQueryHandler : IRequestHandler<GetOccupiedRoomDaysQuery, Response<IEnumerable<DateTime>>>
    {
        private readonly IRepository<Booking> _repository;

        public GetOccupiedRoomDaysQueryHandler(IRepository<Booking> repository)
        {
            _repository = repository;
        }

        public async Task<Response<IEnumerable<DateTime>>> Handle(GetOccupiedRoomDaysQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll(x => x.Id == request.Id);
            return new Response<IEnumerable<DateTime>>(result.Select(x=>x.Date.ToUTCKind()));
        }
    }
}
