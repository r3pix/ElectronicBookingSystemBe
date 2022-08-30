using ElectronicBookingSystem.Infrastructure.Models;
using ElectronicBookingSystem.Infrastructure.Models.Decoration;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Decoration.Queries
{
    public class GetPageableDecorationsQuery : IRequest<Response<PageableModel<DecorationListModel>>>
    {
        public GetPageableDecorationsFilter Filter { get; set; }
        public Page Page { get; set; }

        public static GetPageableDecorationsQuery Create(GetPageableDecorationsDto dto)
        {
            return new GetPageableDecorationsQuery
            {
                Filter = new GetPageableDecorationsFilter
                {
                    SearchTerm = dto.SearchTerm
                },
                Page = new Page
                {
                    PageNumber = dto.PageNumber,
                    PageSize = dto.PageSize,
                    OrderBy = dto.OrderBy,
                    Desc = dto.Desc
                }
            };
        }
    }
}
