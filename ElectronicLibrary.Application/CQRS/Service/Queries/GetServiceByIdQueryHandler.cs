using AutoMapper;
using ElectronicBookingSystem.Infrastructure.Models.Service;
using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Service.Queries
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, Response<ServiceModel>>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public GetServiceByIdQueryHandler(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task<Response<ServiceModel>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _serviceRepository.GetById(request.Id);
            var result = _mapper.Map<ServiceModel>(entity);
            return new Response<ServiceModel>(result);
        }
    }
}
