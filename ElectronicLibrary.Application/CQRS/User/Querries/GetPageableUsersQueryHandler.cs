using AutoMapper;
using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Infrastructure.Models.User;
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
    public class GetPageableUsersQueryHandler : IRequestHandler<GetPageableUsersQuery, Response<PageableModel<UserListModel>>>
    {
        private readonly IUserPageableRepository _repository;
        private readonly IMapper _mapper;

        public GetPageableUsersQueryHandler(IUserPageableRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<PageableModel<UserListModel>>> Handle(GetPageableUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetPageable(request.Filter, request.Page);
            var mappedResult = _mapper.Map<IEnumerable<UserListModel>>(result.Item1);
            return new Response<PageableModel<UserListModel>>(new PageableModel<UserListModel>(mappedResult, result.Item2));
        }
    }
}
