using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Address.Commands;
using ElectronicBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Profiles
{
    public class AddressAutomapperProfile : Profile
    {
        public AddressAutomapperProfile()
        {
            CreateMap<UpdateAddressCommand, Address>();
        }
    }
}
