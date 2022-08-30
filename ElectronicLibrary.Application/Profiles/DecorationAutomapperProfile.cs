using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Decoration.Commands;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Models.Decoration;
using ElectronicLibrary.Application.CQRS.Decoration.Commands;
using ElectronicLibrary.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Profiles
{
    public class DecorationAutomapperProfile : Profile
    {
        /*
        public class MapFileAddressAction : IMappingAction<Decoration, DecorationModel>
        {
            private readonly FileConfiguration _fileConfiguration;

            public MapFileAddressAction(FileConfiguration fileConfiguration)
            {
                _fileConfiguration = fileConfiguration;
            }

            public void Process(Decoration source, DecorationModel destination, ResolutionContext context)
            {
                destination.FileAddress = String.Format(_fileConfiguration.FileControllerAddress, source.File.Id);
            }
        }
        */

        public DecorationAutomapperProfile()
        {
            CreateMap<AddDecorationCommand, Decoration>();
            //.ForMember(dest => dest.File, opt => opt.Ignore());

            CreateMap<Decoration, DecorationModel>()
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Cost))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            //.AfterMap<MapFileAddressAction>();

            CreateMap<UpdateDecorationCommand, Decoration>();
            CreateMap<Decoration,DecorationListModel>()
                .ForMember(dest=>dest.FileId, opt=>opt.MapFrom(src=>src.Files.FirstOrDefault().Id));
        }
    }
}
