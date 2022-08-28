using ElectronicBookingSystem.Infrastructure.Models;
using ElectronicBookingSystem.Infrastructure.Models.Category;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Category.Queries
{
    public class GetPageableCategoriesQuery : IRequest<Response<PageableModel<CategoryListModel>>>
    {
        public GetPageableCategoriesFilter Filter { get; set; }
        public Page Page { get; set; }

        public static GetPageableCategoriesQuery Create(GetPageableCategoriesDto dto)
        {
            return new GetPageableCategoriesQuery
            {
                Page = new Page
                {
                    PageNumber = dto.PageNumber,
                    PageSize = dto.PageSize,
                    OrderBy = dto.OrderBy,
                    Desc = dto.Desc,
                },
                Filter = new GetPageableCategoriesFilter
                {
                    SearchTerm = dto.SearchTerm
                }

            };
        }
    }
}
