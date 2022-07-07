using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.User.Querries
{
    public class LoginUserQuery : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
