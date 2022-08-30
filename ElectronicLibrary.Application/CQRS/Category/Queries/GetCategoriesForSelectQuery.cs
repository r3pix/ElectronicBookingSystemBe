using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Category.Queries
{
    public class GetCategoriesForSelectQuery : ISelectQueryModel, IRequest<Response<IEnumerable<SelectModel<Guid>>>>
    {
        public string FilterWords { get; set; }
    }
}
