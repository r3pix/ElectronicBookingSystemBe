using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.File.Queries
{
    public class GetFileByIdQuery : IRequest<(byte[],string)>
    {
        public Guid Id { get; set; }
    }
}
