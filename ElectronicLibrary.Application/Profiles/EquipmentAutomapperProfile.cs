using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Equipment.Commands;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Models.Equipment;
using ElectronicLibrary.Application.CQRS.Equipment.Commands;
using ElectronicLibrary.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Profiles
{
    public class EquipmentAutomapperProfile : Profile
    {
        /*
        public class EquipmentFileAddressAction : IMappingAction<Equipment, EquipmentModel>
        {
            private readonly FileConfiguration _fileConfiguration;

            public EquipmentFileAddressAction(FileConfiguration fileConfiguration)
            {
                _fileConfiguration = fileConfiguration;
            }

            public void Process(Equipment source, EquipmentModel destination, ResolutionContext context)
            {
                destination.FileAddress = string.Format(_fileConfiguration.FileControllerAddress,source.File.Id); 
            }
        }*/

        public EquipmentAutomapperProfile()
        {
            CreateMap<AddEquipmentCommand, Equipment>();
            //.ForMember(dest=>dest.File, opt=>opt.Ignore());

            CreateMap<Equipment, EquipmentModel>()
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Cost))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.FileId, opt => opt.MapFrom(src => src.Files.OrderByDescending(x => x.CreateDate).First().Id));
            //.AfterMap<EquipmentFileAddressAction>();

            CreateMap<UpdateEquipmentCommand,Equipment>();

            CreateMap<Equipment, EquipmentListModel>()
                .ForMember(dest=>dest.FileId, opt=>opt.MapFrom(src=>src.Files.OrderByDescending(x=>x.CreateDate).FirstOrDefault().Id));
        }
    }
}
