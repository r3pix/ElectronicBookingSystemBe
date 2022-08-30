using AutoMapper;
using ElectronicBookingSystem.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Extensions;
using ElectronicLibrary.Infrastructure.Models.Room;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Room.Queries
{
    public class GetPageableRoomsQueryHandler : IRequestHandler<GetPageableRoomsQuery, Response<PageableModel<RoomListModel>>>
    {
        private readonly IRoomPageableRepository _repository;
        private readonly IMapper _mapper;

        public GetPageableRoomsQueryHandler(IRoomPageableRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<PageableModel<RoomListModel>>> Handle(GetPageableRoomsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetPageable(request.Filter, request.Page);
            var mappedResult = _mapper.Map<IEnumerable<RoomListModel>>(result.Item1);

            return new Response<PageableModel<RoomListModel>>(new PageableModel<RoomListModel>(mappedResult, result.Item2)); 
        }
    }
}
