using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Booking.Commands
{
    public class CancelBookingCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
