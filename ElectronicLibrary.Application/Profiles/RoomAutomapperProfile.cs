﻿using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Room.Commands;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Application.CQRS.Room.Commands;
using ElectronicLibrary.Infrastructure.Models;
using ElectronicLibrary.Infrastructure.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Profiles
{
    /// <summary>
    /// Automapper class for Room entity
    /// </summary>
    public class RoomAutomapperProfile : Profile
    {
        /*public class SetFileDownloadAddressAction : IMappingAction<Room, RoomListModel>
        {
            private readonly FileConfiguration _fileConfiguration;

            public SetFileDownloadAddressAction(FileConfiguration fileConfiguration)
            {
                _fileConfiguration = fileConfiguration;
            }

            public void Process(Room source, RoomListModel destination, ResolutionContext context)
            {
                destination.FileAddress = string.Format(_fileConfiguration.FileControllerAddress, source.File.Id);
            }
        }*/

        public RoomAutomapperProfile()
        {
            CreateMap<AddRoomCommand, Room>()
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TotalMaxPlaces, opt => opt.MapFrom(src => src.TotalMaxPlaces))
                .ForMember(dest => dest.TotalMaxTables, opt => opt.MapFrom(src => src.TotalMaxTables))
                .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width));
                //.ForMember(dest => dest.File, opt => opt.Ignore());

            CreateMap<Room, RoomListModel>()
                //.AfterMap<SetFileDownloadAddressAction>(); //trzeba dodac include
                .ForMember(x => x.FileId, opt => opt.MapFrom(x => x.Files.OrderByDescending(x=>x.CreateDate).FirstOrDefault().Id))
                .ForMember(x=>x.CategoryName, opt=>opt.MapFrom(src=>src.Category.Name));

            CreateMap<UpdateRoomCommand, Room>();
        }
    }
}
