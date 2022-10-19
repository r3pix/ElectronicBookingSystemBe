using AutoMapper;
using ElectronicLibrary.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElectronicBookingSystem.Infrastructure.Interfaces;

namespace ElectronicLibrary.Application.CQRS.User.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IRepository<ElectronicBookingSystem.Domain.Entities.User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<ElectronicBookingSystem.Domain.Entities.User> _passwordHasher;
        private readonly IRepository<ElectronicBookingSystem.Domain.Entities.Role> _roleRepository;
        private readonly IEmailSender _emailSender;
        private readonly IInlineEmailMessageService _inlineEmailMessageService;

        public RegisterUserCommandHandler(IRepository<ElectronicBookingSystem.Domain.Entities.User> userRepository, IMapper mapper, 
            IPasswordHasher<ElectronicBookingSystem.Domain.Entities.User> passwordHasher, 
            IRepository<ElectronicBookingSystem.Domain.Entities.Role> roleRepository, IEmailSender emailSender,
            IInlineEmailMessageService inlineEmailMessageService) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _roleRepository = roleRepository;
            _emailSender = emailSender;
            _inlineEmailMessageService = inlineEmailMessageService;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ElectronicBookingSystem.Domain.Entities.User>(request);
            var role = await _roleRepository.GetByPredicate(x => x.Name == "User");
            entity.PasswordHash = _passwordHasher.HashPassword(entity, request.Password);
            entity.RoleId = role.Id;
            await _userRepository.Save(entity);
            await _emailSender.SendEmailAsync(entity.Email,$"Założenie konta na adres: {request.Email}",await _inlineEmailMessageService.GetHtmlRegisterMessage(request.Email));
            return default;
        }
    }
}
