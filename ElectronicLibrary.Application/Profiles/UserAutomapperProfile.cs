using AutoMapper;
using ElectronicBookingSystem.Infrastructure.Models.User;
using ElectronicLibrary.Application.CQRS.User.Commands;
using ElectronicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Profiles
{
    public class UserAutomapperProfile : Profile
    {
        public UserAutomapperProfile()
        {
            CreateMap<RegisterUserCommand, User>() //dodac mapowanie!
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .AfterMap((src, dest) =>
                {
                    //intialize lower level entities
                    dest.Address = new Address();
                    dest.Identity = new Identity();
                    //
                    dest.Address.City = src.City;
                    dest.Address.Number = src.Number;
                    dest.Address.PostalCode = src.PostalCode;
                    dest.Address.Street = src.Street;
                    dest.Identity.Name = src.Name;
                    dest.Identity.LastName = src.LastName;
                });

            CreateMap<User, UserData>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Identity.LastName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Identity.Name))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));
        }
    }
}
