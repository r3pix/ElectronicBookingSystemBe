using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Opinion.Queries
{
    public class CheckIsOpinionAllowedQueryHandler : IRequestHandler<CheckIsOpinionAllowedQuery, Response<bool>>
    {
        private readonly IRepository<Domain.Entities.Booking> _repository;

        public CheckIsOpinionAllowedQueryHandler(IRepository<Domain.Entities.Booking> repository)
        {
            _repository = repository;
        }

        public async Task<Response<bool>> Handle(CheckIsOpinionAllowedQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetQueryable().Include(x => x.Room).ThenInclude(x => x.Opinions)
                .AnyAsync(x => x.RoomId == request.RoomId && x.UserId == request.UserId && !x.Room.Opinions.Any(x => x.UserId == request.UserId));

            return new Response<bool>(result);
        }
    }
}
