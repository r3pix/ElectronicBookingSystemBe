using AutoMapper;
using ElectronicLibrary.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.User.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IRepository<Domain.Entities.User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;
        private readonly IRepository<Domain.Entities.Role> _roleRepository;

        public RegisterUserCommandHandler(IRepository<Domain.Entities.User> userRepository, IMapper mapper, IPasswordHasher<Domain.Entities.User> passwordHasher, IRepository<Domain.Entities.Role> roleRepository) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _roleRepository = roleRepository;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.User>(request);
            var role = await _roleRepository.GetByPredicate(x => x.Name == "User");
            entity.PasswordHash = _passwordHasher.HashPassword(entity, request.Password);
            entity.RoleId = role.Id;
            await _userRepository.Save(entity);
            return default;
        }
    }
}
