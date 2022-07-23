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
    public class GetUserDataQueryHandler : IRequestHandler<GetUserDataQuery, Response<UserData>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDataQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response<UserData>> Handle(GetUserDataQuery request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetByPredicate(x=>x.Email == request.Email);
            var result = _mapper.Map<UserData>(entity);
            return new Response<UserData>(result);
        }
    }
}
