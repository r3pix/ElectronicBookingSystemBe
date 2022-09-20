using ElectronicBookingSystem.Infrastructure.Models;
using ElectronicBookingSystem.Infrastructure.Models.Booking;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Booking.Queries
{
    public class GetPageableBookingsQuery : IRequest<Response<PageableModel<BookingListModel>>>
    {
        public GetPageableBookingsQueryFilter Filter { get; set; }
        public Page Page { get; set; }

        public static GetPageableBookingsQuery Create(GetPageableBookingsQueryDto dto)
        {
            return new GetPageableBookingsQuery
            {
                Filter = new GetPageableBookingsQueryFilter
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
