using AutoMapper;
using ElectronicLibrary.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Service.Commands
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IServiceRepository _repository;
        private readonly IMapper _mapper;

        public UpdateServiceCommandHandler(IServiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Service>(request);
            await _repository.Update(entity);
            return default;
        }
    }
}
