using AutoMapper;
using ElectronicLibrary.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Opinion.Commands
{
    public class AddOpinionCommandHandler : IRequestHandler<AddOpinionCommand>
    {
        private readonly IRepository<Domain.Entities.Opinion> _repository;
        private readonly IMapper _mapper;

        public AddOpinionCommandHandler(IRepository<Domain.Entities.Opinion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddOpinionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Opinion>(request);
            await _repository.Save(entity);
            return default;
        }
    }
}
