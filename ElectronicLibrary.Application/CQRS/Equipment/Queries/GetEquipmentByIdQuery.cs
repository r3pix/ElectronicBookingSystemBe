using ElectronicBookingSystem.Infrastructure.Models.Equipment;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Equipment.Queries
{
    public class GetEquipmentByIdQuery : IRequest<Response<EquipmentModel>>
    {
        public Guid Id { get; set; }
    }
}
