﻿using ElectronicBookingSystem.Infrastructure.Models.Booking;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Booking.Queries
{
    public class GetBookingInvoiceDataQuery : IRequest<Response<BookingInvoiceModel>> 
    {
        public Guid Id { get; set; }
    }
}
