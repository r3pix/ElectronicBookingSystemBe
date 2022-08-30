using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Decoration.Commands
{
    public class UpdateDecorationCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
    }
}
