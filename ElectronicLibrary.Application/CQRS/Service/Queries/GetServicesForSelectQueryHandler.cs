using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.Service.Queries
{
    public class GetServicesForSelectQueryHandler : IRequestHandler<GetServicesForSelectQuery, Response<IEnumerable<SelectModel<Guid>>>>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetServicesForSelectQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Response<IEnumerable<SelectModel<Guid>>>> Handle(GetServicesForSelectQuery request, CancellationToken cancellationToken)
        {
            var result = await _serviceRepository.GetForSelect(request);
            return new Response<IEnumerable<SelectModel<Guid>>>(result);
        }
    }
}
