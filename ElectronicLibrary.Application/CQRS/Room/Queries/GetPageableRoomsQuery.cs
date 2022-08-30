using ElectronicBookingSystem.Infrastructure.Models;
using ElectronicBookingSystem.Infrastructure.Models.Category;
using ElectronicBookingSystem.Infrastructure.Models.Room;
using ElectronicLibrary.Infrastructure.Extensions;
using ElectronicLibrary.Infrastructure.Models.Room;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Room.Queries
{
    public class GetPageableRoomsQuery : IRequest<Response<PageableModel<RoomListModel>>>
    {
        public GetPageableRoomsFilter Filter { get; set; }
        public Page Page { get; set; }

        public static GetPageableRoomsQuery Create(GetPageableRoomsDto dto)
        {
            return new GetPageableRoomsQuery
            {
                Filter = new GetPageableRoomsFilter
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
