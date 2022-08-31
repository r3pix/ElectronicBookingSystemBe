using AutoMapper;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Equipment.Commands
{
    public class UpdateEquipmentCommandHandler : IRequestHandler<UpdateEquipmentCommand>
    {
        private readonly IEquipmentRepository _repository;
        private readonly IMapper _mapper;

        public UpdateEquipmentCommandHandler(IEquipmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEquipmentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Equipment>(request);
            await _repository.Update(entity);
            return default;
        }
    }
}
