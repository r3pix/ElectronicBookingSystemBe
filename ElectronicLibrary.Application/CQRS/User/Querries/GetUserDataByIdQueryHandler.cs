using AutoMapper;
using ElectronicBookingSystem.Infrastructure.Models.User;
using ElectronicLibrary.Application.Repositories;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.User.Querries
{
    public class GetUserDataByIdQueryHandler : IRequestHandler<GetUserDataByIdQuery, Response<UserListModel>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUserDataByIdQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<UserListModel>> Handle(GetUserDataByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByPredicate(x=>x.Id == request.Id);
            var mappedEntity = _mapper.Map<UserListModel>(entity);
            return new Response<UserListModel>(mappedEntity);
        }
    }
}
