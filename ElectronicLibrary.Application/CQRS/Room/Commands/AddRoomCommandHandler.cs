using AutoMapper;
using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Models;
using ElectronicLibrary.Infrastructure.Services;
using ElectronicBookingSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.Room.Commands
{
    public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand>
    {
        private readonly IFileService _fileService;
        private readonly FileConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IRepository<ElectronicBookingSystem.Domain.Entities.Room> _roomRepository;
        private readonly IRepository<ElectronicBookingSystem.Domain.Entities.File> _fileRepository;

        public AddRoomCommandHandler(IRepository<ElectronicBookingSystem.Domain.Entities.Room> roomRepository, IRepository<ElectronicBookingSystem.Domain.Entities.File> fileRepository, IFileService fileService, FileConfiguration configuration, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _fileRepository = fileRepository;
            _fileService = fileService;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddRoomCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ElectronicBookingSystem.Domain.Entities.Room>(request);
            entity = await _roomRepository.Save(entity);

            await _fileRepository.Save(new ElectronicBookingSystem.Domain.Entities.File()
            {
                FileName = request.File.FileName,
                PathFileName = Path.Combine(_configuration.UploadPath, entity.Id.ToString(), request.File.FileName),
                UploadPath = Path.Combine(_configuration.UploadPath,entity.Id.ToString()),
                RoomId = entity.Id
            });

            await _fileService.Save(Path.Combine(_configuration.UploadPath,entity.Id.ToString()),request.File);
            
            return default;
        }
    }
}
