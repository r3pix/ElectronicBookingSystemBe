using AutoMapper;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Application.CQRS.Booking.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Profiles
{
    public class BookingAutomapperProfile : Profile
    {
        public BookingAutomapperProfile()
        {
            CreateMap<AddBookingCommand, Booking>();
        }
    }
}
