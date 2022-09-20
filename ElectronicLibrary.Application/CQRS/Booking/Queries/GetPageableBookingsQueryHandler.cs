using AutoMapper;
using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Infrastructure.Models.Booking;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Booking.Queries
{
    public class GetPageableBookingsQueryHandler : IRequestHandler<GetPageableBookingsQuery, Response<PageableModel<BookingListModel>>>
    {
        private readonly IBookingPageableRepository _repository;
        private readonly IMapper _mapper;

        public GetPageableBookingsQueryHandler(IBookingPageableRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<PageableModel<BookingListModel>>> Handle(GetPageableBookingsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetPageable(request.Filter, request.Page);
            var mappedResult = _mapper.Map<IEnumerable<BookingListModel>>(result.Item1);
            return new Response<PageableModel<BookingListModel>>(new PageableModel<BookingListModel>(mappedResult, result.Item2));
        }
    }
}
