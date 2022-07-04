using AutoMapper;
using ElectronicLibrary.Application.CQRS.Equipment.Commands;
using ElectronicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Profiles
{
    public class EquipmentAutomapperProfile : Profile
    {
        public EquipmentAutomapperProfile()
        {
            CreateMap<AddEquipmentCommand,Equipment>()
                .ForMember(dest=>dest.File, opt=>opt.Ignore());
        }
    }
}
