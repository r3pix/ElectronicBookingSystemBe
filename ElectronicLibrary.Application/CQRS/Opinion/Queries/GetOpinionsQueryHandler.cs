using AutoMapper;
using ElectronicBookingSystem.Infrastructure.Models.Opinion;
using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Opinion.Queries
{
    public class GetOpinionsQueryHandler : IRequestHandler<GetOpinionsQuery, Response<IEnumerable<OpinionModel>>>
    {
        private readonly IRepository<Domain.Entities.Opinion> _repository;
        private readonly IMapper _mapper;

        public GetOpinionsQueryHandler(IRepository<Domain.Entities.Opinion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<OpinionModel>>> Handle(GetOpinionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetQueryable().Include(x => x.User).ThenInclude(x => x.Identity).OrderByDescending(x => x.CreateDate).Where(x => x.RoomId == request.RoomId).ToListAsync();
            var mappedResult = _mapper.Map<IEnumerable<OpinionModel>>(result);
            return new Response<IEnumerable<OpinionModel>>(mappedResult);
        }
    }
}
