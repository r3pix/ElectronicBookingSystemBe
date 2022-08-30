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

namespace ElectronicBookingSystem.Application.CQRS.Decoration.Commands
{
    public class UpdateDecorationCommandHandler : IRequestHandler<UpdateDecorationCommand>
    {
        private readonly IDecorationRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDecorationCommandHandler(IDecorationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateDecorationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Decoration>(request);
            await _repository.Update(entity);
            return default;
        }
    }
}
