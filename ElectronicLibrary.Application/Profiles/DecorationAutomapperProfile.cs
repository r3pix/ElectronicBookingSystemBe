using AutoMapper;
using ElectronicLibrary.Application.CQRS.Decoration.Commands;
using ElectronicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Profiles
{
    public class DecorationAutomapperProfile : Profile
    {
        public DecorationAutomapperProfile()
        {
            CreateMap<AddDecorationCommand, Decoration>()
                .ForMember(dest => dest.File, opt => opt.Ignore());
        }
    }
}
