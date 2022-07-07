using AutoMapper;
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
                    dest.Identity.LastName = src.Name;
                });
        }
    }
}
