using ElectronicBookingSystem.Infrastructure.Models;
using ElectronicBookingSystem.Infrastructure.Models.User;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.User.Querries
{
    public class GetPageableUsersQuery : IRequest<Response<PageableModel<UserListModel>>>
    {
        public GetPageableUsersFilter Filter { get; set; }
        public Page Page { get; set; }

        public static GetPageableUsersQuery Create(GetPageableUsersDto dto)
        {
            return new GetPageableUsersQuery
            {
                Page = new Page
                {
                    PageSize = dto.PageSize,
                    PageNumber = dto.PageNumber,
                    OrderBy = dto.OrderBy,
                    Desc = dto.Desc
                },
                Filter = new GetPageableUsersFilter
                {
                    SearchTerm = dto.SearchTerm
                }
            };
        }
    }
}
