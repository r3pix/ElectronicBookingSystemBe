using ElectronicBookingSystem.Infrastructure.Models.Decoration;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;

namespace ElectronicBookingSystem.Application.CQRS.Decoration.Queries
{
    public class GetDecorationByIdQuery : IRequest<Response<DecorationModel>>
    {
        public Guid Id { get; set; }
    }
}
