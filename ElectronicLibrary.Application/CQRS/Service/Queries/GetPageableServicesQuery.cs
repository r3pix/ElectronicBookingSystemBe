using ElectronicBookingSystem.Infrastructure.Models;
using ElectronicBookingSystem.Infrastructure.Models.Service;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Service.Queries
{
    public class GetPageableServicesQuery : IRequest<Response<PageableModel<ServiceListModel>>>
    {
        public GetPageableServicesFilter Filter { get; set; }
        public Page Page { get; set; }

        public static GetPageableServicesQuery Create(GetPageableServicesDto dto)
        {
            return new GetPageableServicesQuery
            {
                Page = new Page
                {
                    PageNumber = dto.PageNumber,
                    PageSize = dto.PageSize,
                    OrderBy = dto.OrderBy,
                    Desc = dto.Desc
                },
                Filter = new GetPageableServicesFilter
                {
                    SearchTerm = dto.SearchTerm
                }
            };
        }
    }
}
