﻿using AutoMapper;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Address.Commands
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IRepository<Domain.Entities.Address> _repository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IRepository<Domain.Entities.Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(request.Id);
            if(entity is null)
            {
                throw new Exception("Data is not present");
            }
            _mapper.Map(request,entity);
            await _repository.SaveChangesAsync();
            return default;
        }
    }
}
