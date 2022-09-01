using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Identity.Commands;
using ElectronicBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Profiles
{
    public class IdentityAutomapperProfile : Profile
    {
        public IdentityAutomapperProfile()
        {
            CreateMap<UpdateIdentityCommand, Identity>();
        }
    }
}
