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

namespace ElectronicBookingSystem.Application.CQRS.Identity.Commands
{
    public class UpdateIdentityCommandHandler : IRequestHandler<UpdateIdentityCommand>
    {
        private readonly IRepository<Domain.Entities.Identity> _repository;
        private readonly IMapper _mapper;

        public UpdateIdentityCommandHandler(IRepository<Domain.Entities.Identity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateIdentityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(request.Id);
            _mapper.Map(request, entity);
            await _repository.SaveChangesAsync();
            return default;
        }
    }
}
