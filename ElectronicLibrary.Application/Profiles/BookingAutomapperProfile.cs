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

            CreateMap<Booking, BookingInvoiceModel>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToUTCKind()))
                .ForMember(dest => dest.DecorationCost, opt => opt.MapFrom(src => src.Decoration.Cost))
                .ForMember(dest => dest.DecorationName, opt => opt.MapFrom(src => src.Decoration.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.EquipmentCost, opt => opt.MapFrom(src => src.Equipment.Cost))
                .ForMember(dest => dest.EquipmentName, opt => opt.MapFrom(src => src.Equipment.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.Identity.Name)) 
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.Identity.LastName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.RoomCost, opt => opt.MapFrom(src => src.Room.Cost))
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room.Name))
                .ForMember(dest => dest.ServiceCost, opt => opt.MapFrom(src => src.Service.Cost))
                .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name))
                .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => src.TotalCost))
                .ForMember(dest => dest.TotalPlaces, opt => opt.MapFrom(src => src.TotalPlaces))
                .ForMember(dest => dest.TotalTables, opt => opt.MapFrom(src => src.TotalTables));

        }
    }
}
