using AutoMapper;
using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Infrastructure.Models.Equipment;
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
    public class GetPageableEquipmentQueryHandler : IRequestHandler<GetPageableEquipmentQuery, Response<PageableModel<EquipmentListModel>>>
    {
        private readonly IPageableEquipmentRepository _repository;
        private readonly IMapper _mapper;

        public GetPageableEquipmentQueryHandler(IPageableEquipmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<PageableModel<EquipmentListModel>>> Handle(GetPageableEquipmentQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetPageable(request.Filter,request.Page);
            var mappedResult = _mapper.Map<IEnumerable<EquipmentListModel>>(result.Item1);

            return new Response<PageableModel<EquipmentListModel>>(new PageableModel<EquipmentListModel>(mappedResult,result.Item2));
        }
    }
}
