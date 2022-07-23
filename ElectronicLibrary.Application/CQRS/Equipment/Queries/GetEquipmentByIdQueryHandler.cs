using AutoMapper;
using ElectronicBookingSystem.Infrastructure.Models.Equipment;
using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Equipment.Queries
{
    public class GetEquipmentByIdQueryHandler : IRequestHandler<GetEquipmentByIdQuery, Response<EquipmentModel>>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;

        public GetEquipmentByIdQueryHandler(IEquipmentRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        public async Task<Response<EquipmentModel>> Handle(GetEquipmentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _equipmentRepository.GetById(request.Id);
            var result = _mapper.Map<EquipmentModel>(entity);
            return new Response<EquipmentModel>(result);
        }
    }
}
