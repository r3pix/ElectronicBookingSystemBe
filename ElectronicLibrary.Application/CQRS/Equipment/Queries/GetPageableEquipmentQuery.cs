using ElectronicBookingSystem.Infrastructure.Models;
using ElectronicBookingSystem.Infrastructure.Models.Equipment;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Equipment.Queries
{
    public class GetPageableEquipmentQuery : IRequest<Response<PageableModel<EquipmentListModel>>>
    {
        public GetPageableEquipmentFilter Filter { get; set; }
        public Page Page { get; set; }

        public static GetPageableEquipmentQuery Create(GetPageableEquipmentDto dto)
        {
            return new GetPageableEquipmentQuery
            {
                Page = new Page
                {
                    PageNumber = dto.PageNumber,
                    PageSize = dto.PageSize,
                    OrderBy = dto.OrderBy,
                    Desc = dto.Desc
                },
                Filter = new GetPageableEquipmentFilter
                {
                    SearchTerm = dto.SearchTerm
                }
            };
        }
    }
}
