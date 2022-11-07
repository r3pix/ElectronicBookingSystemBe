using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Opinion.Commands;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Extensions;
using ElectronicBookingSystem.Infrastructure.Models.Opinion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Profiles
{
    public class OpinionAutomapperProfile : Profile
    {
        public OpinionAutomapperProfile()
        {
            CreateMap<AddOpinionCommand, Opinion>();

            CreateMap<Opinion, OpinionModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.Identity.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest=>dest.CreateDate, opt=>opt.MapFrom(src=>src.CreateDate.ToUTCKind()));
                
        }
    }
}
