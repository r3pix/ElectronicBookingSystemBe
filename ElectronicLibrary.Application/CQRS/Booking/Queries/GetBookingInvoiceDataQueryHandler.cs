using AutoMapper;
using ElectronicBookingSystem.Infrastructure.Models.Booking;
using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Booking.Queries
{
    public class GetBookingInvoiceDataQueryHandler : IRequestHandler<GetBookingInvoiceDataQuery, Response<BookingInvoiceModel>>
    {
        private readonly IRepository<Domain.Entities.Booking> _repository;
        private readonly IMapper _mapper;

        public GetBookingInvoiceDataQueryHandler(IRepository<Domain.Entities.Booking> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<BookingInvoiceModel>> Handle(GetBookingInvoiceDataQuery request, CancellationToken cancellationToken)
        {
            var data = await GetBookingData(request.Id);
            if(data is null)
            {
                throw new Exception("Not found");
            }
            return new Response<BookingInvoiceModel>(_mapper.Map<BookingInvoiceModel>(data));
        }

        public async Task<Domain.Entities.Booking> GetBookingData(Guid id) =>
            await _repository.GetQueryable()
                .Include(x => x.User).ThenInclude(x => x.Identity)
                .Include(x => x.Service)
                .Include(x => x.Room)
                .Include(x => x.Equipment)
                .Include(x => x.Decoration)
                .FirstOrDefaultAsync(x=>x.Id == id);
    }
}
