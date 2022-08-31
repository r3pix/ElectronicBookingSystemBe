using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Equipment.Commands
{
    public class EditEquipmentPictureCommand : IRequest
    {
        public Guid EquipmentId { get; set; }
        public IFormFile File { get; set; }
    }
}
