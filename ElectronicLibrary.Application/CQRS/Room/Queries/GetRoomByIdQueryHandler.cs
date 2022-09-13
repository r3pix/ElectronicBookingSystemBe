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

namespace ElectronicBookingSystem.Application.CQRS.Room.Queries
{
    public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, Response<RoomListModel>>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public GetRoomByIdQueryHandler(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<Response<RoomListModel>> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _roomRepository.GetById(request.Id);
            var mappedResult = _mapper.Map<RoomListModel>(result);
            return new Response<RoomListModel>(mappedResult);
        }
    }
}
