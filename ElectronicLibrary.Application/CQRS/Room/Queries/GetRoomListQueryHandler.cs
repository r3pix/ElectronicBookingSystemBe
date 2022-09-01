using AutoMapper;
using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Extensions;
using ElectronicLibrary.Infrastructure.Models.Room;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.Room.Queries
{
    public class GetRoomListQueryHandler : IRequestHandler<GetRoomListQuery, Response<IEnumerable<RoomListModel>>>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public GetRoomListQueryHandler(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<RoomListModel>>> Handle(GetRoomListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _roomRepository.GetAll(request.Filter);
            var result = _mapper.Map<IEnumerable<RoomListModel>>(entities);
            return new Response<IEnumerable<RoomListModel>>(result);

        }
    }
}
