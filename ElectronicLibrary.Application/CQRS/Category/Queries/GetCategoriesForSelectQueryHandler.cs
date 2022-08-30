using ElectronicBookingSystem.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Category.Queries
{
    public class GetCategoriesForSelectQueryHandler : IRequestHandler<GetCategoriesForSelectQuery, Response<IEnumerable<SelectModel<Guid>>>>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoriesForSelectQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<IEnumerable<SelectModel<Guid>>>> Handle(GetCategoriesForSelectQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetForSelect(request);
            return new Response<IEnumerable<SelectModel<Guid>>>(result);
        }
    }
}
