using AutoMapper;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Extensions;
using ElectronicBookingSystem.Infrastructure.Models.Booking;
using ElectronicLibrary.Application.CQRS.Booking.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Profiles
{
    public class BookingAutomapperProfile : Profile
    {
        public BookingAutomapperProfile()
        {
            CreateMap<AddBookingCommand, Booking>();
            CreateMap<Booking, BookingListModel>()
                .ForMember(dest => dest.DecorationName, opt => opt.MapFrom(src => src.Decoration.Name))
                .ForMember(dest => dest.EquipmentName, opt => opt.MapFrom(src => src.Equipment.Name))
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room.Name))
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Identity.Name))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.Identity.Name))
                .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.User.Role.Name))
                .ForMember(dest=>dest.Date, opt=>opt.MapFrom(src=>src.Date.ToUTCKind()));

        }
    }
}
