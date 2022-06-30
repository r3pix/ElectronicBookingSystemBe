using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.Decoration.Queries
{
    public class GetDecorationsForSelectQueryHandler : IRequestHandler<GetDecorationsForSelectQuery, Response<IEnumerable<SelectModel<Guid>>>>
    {
        private readonly IDecorationRepository _repository;

        public GetDecorationsForSelectQueryHandler(IDecorationRepository repository)
        {
            _repository = repository;
        }


        public async Task<Response<IEnumerable<SelectModel<Guid>>>> Handle(GetDecorationsForSelectQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetForSelect(request);
            return new Response<IEnumerable<SelectModel<Guid>>>(result);
        }
    }
}
