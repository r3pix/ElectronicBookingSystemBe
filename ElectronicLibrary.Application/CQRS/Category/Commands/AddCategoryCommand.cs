using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Category.Commands
{
    public class AddCategoryCommand : IRequest
    {
        public string Name { get; set; }
    }
}
