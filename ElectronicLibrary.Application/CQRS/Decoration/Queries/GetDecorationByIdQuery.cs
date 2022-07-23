using ElectronicBookingSystem.Infrastructure.Models.Decoration;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Decoration.Queries
{
    public class GetDecorationByIdQuery : IRequest<Response<DecorationModel>>
    {
        public Guid Id { get; set; }
    }
}
