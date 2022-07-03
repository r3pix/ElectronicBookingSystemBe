using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.Service.Queries
{
    public class GetServicesForSelectQuery : ISelectQueryModel, IRequest<Response<IEnumerable<SelectModel<Guid>>>>
    {
        public string FilterWords {get; set;}
    }
}
