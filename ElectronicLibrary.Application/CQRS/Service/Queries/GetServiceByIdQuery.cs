using ElectronicBookingSystem.Infrastructure.Models.Service;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Service.Queries
{
    public class GetServiceByIdQuery : IRequest<Response<ServiceModel>>
    {
        public Guid Id { get; set; }
    }
}
