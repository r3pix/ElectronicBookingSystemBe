using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.Equipment.Queries
{
    public class GetEquipmentForSelectQueryHandler : IRequestHandler<GetEquipmentForSelectQuery, Response<IEnumerable<SelectModel<Guid>>>>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public GetEquipmentForSelectQueryHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<Response<IEnumerable<SelectModel<Guid>>>> Handle(GetEquipmentForSelectQuery request, CancellationToken cancellationToken)
        {
            var result = await _equipmentRepository.GetForSelect(request);
            return new Response<IEnumerable<SelectModel<Guid>>>(result);
        }
    }
}
