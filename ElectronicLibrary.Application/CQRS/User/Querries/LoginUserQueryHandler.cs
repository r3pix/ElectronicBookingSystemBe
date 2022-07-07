using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Application.Repositories;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.User.Querries
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, Response<string>>
    {
        private readonly IRepository<Domain.Entities.User> _userRepository;
        private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;
        private readonly IConfiguration _configuration;

        public LoginUserQueryHandler(IUserRepository userRepository, IPasswordHasher<Domain.Entities.User> passwordHasher, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public async Task<Response<string>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByPredicate(x => x.Email == request.Email);//trzeba dodac repozytorium i zrobic includy !!!
            if (user is null)
                throw new Exception("User credentials are wrong!");

            var passwordVerifyResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (passwordVerifyResult == PasswordVerificationResult.Failed)
                throw new Exception("User credentials are wrong!");

            //everything is ok! generate the JWT Bearer
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JWTConfiguration:SecretKey").Get<string>());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Identity.Name),
                    new Claim(ClaimTypes.GivenName, user.Identity.LastName),
                    new Claim(ClaimTypes.Role, user.Role.Name)

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Response<string>(tokenHandler.WriteToken(token));
        }
    }
}
