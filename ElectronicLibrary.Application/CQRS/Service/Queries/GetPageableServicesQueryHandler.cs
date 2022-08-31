using AutoMapper;
using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Infrastructure.Models.Service;
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
    public class GetPageableServicesQueryHandler : IRequestHandler<GetPageableServicesQuery, Response<PageableModel<ServiceListModel>>>
    {
        private readonly IPageableServicesRepository _repository;
        private readonly IMapper _mapper;

        public GetPageableServicesQueryHandler(IPageableServicesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<PageableModel<ServiceListModel>>> Handle(GetPageableServicesQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetPageable(request.Filter, request.Page);
            var mappedResult = _mapper.Map<IEnumerable<ServiceListModel>>(result.Item1);

            return new Response<PageableModel<ServiceListModel>>(new PageableModel<ServiceListModel>(mappedResult, result.Item2));
        }
    }
}
