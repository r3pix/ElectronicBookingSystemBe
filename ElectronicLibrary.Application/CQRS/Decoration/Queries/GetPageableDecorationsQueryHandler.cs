using AutoMapper;
using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Infrastructure.Models.Decoration;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Decoration.Queries
{
    public class GetPageableDecorationsQueryHandler : IRequestHandler<GetPageableDecorationsQuery, Response<PageableModel<DecorationListModel>>>
    {
        private readonly IPageableDecorationsRepository _repository;
        private readonly IMapper _mapper;

        public GetPageableDecorationsQueryHandler(IPageableDecorationsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<PageableModel<DecorationListModel>>> Handle(GetPageableDecorationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetPageable(request.Filter, request.Page);
            var mappedResult = _mapper.Map<IEnumerable<DecorationListModel>>(result.Item1);
            return new Response<PageableModel<DecorationListModel>>(new PageableModel<DecorationListModel>(mappedResult, result.Item2));
        }
    }
}
