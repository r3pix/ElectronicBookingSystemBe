using ElectronicBookingSystem.Infrastructure.Models.User;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.User.Querries
{
    public class GetUserDataQuery : IRequest<Response<UserData>>
    {
        public string Email { get; set; }
    }
}
