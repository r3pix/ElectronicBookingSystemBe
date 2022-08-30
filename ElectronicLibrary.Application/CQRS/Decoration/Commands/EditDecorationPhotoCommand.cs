using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Decoration.Commands
{
    public class EditDecorationPhotoCommand : IRequest
    {
        public Guid DecorationId { get; set; }
        public IFormFile File { get; set; }
    }
}
