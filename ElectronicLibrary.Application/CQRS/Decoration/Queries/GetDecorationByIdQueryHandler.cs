using AutoMapper;
using ElectronicBookingSystem.Infrastructure.Models.Decoration;
using ElectronicLibrary.Application.Interfaces;
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
    public class GetDecorationByIdQueryHandler : IRequestHandler<GetDecorationByIdQuery, Response<DecorationModel>>
    {
        private readonly IDecorationRepository _decorationRepository;
        private readonly IMapper _mapper;

        public GetDecorationByIdQueryHandler(IDecorationRepository decorationRepository, IMapper mapper)
        {
            _decorationRepository = decorationRepository;
        }

        public async Task<Response<DecorationModel>> Handle(GetDecorationByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _decorationRepository.GetById(request.Id);
            var result = _mapper.Map<DecorationModel>(entity);
            return new Response<DecorationModel>(result);
        }
    }
}
