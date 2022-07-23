using AutoMapper;
using ElectronicBookingSystem.Infrastructure.Models.Service;
using ElectronicLibrary.Application.CQRS.Service.Commands;
using ElectronicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Profiles
{
    public class ServiceAutomapperProfile : Profile
    {
        public ServiceAutomapperProfile()
        {
            CreateMap<AddServiceCommand, Service>();
            CreateMap<Service, ServiceModel>();
        }
    }
}
