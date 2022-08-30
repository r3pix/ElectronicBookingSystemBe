using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Models;
using ElectronicLibrary.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Room.Commands
{
    public class EditRoomPictureCommandHandler : IRequestHandler<EditRoomPictureCommand>
    {
        private readonly IRepository<Domain.Entities.File> _repository;
        private readonly IFileService _fileService;
        private readonly FileConfiguration _fileConfiguration;

        public EditRoomPictureCommandHandler(IRepository<Domain.Entities.File> repository, IFileService fileService, FileConfiguration fileConfiguration)
        {
            _repository = repository;
            _fileService = fileService;
            _fileConfiguration = fileConfiguration;
        }

        public async Task<Unit> Handle(EditRoomPictureCommand request, CancellationToken cancellationToken)
        {
            await _repository.Save(new Domain.Entities.File
            {
                RoomId = request.RoomId,
                UploadPath = Path.Combine(_fileConfiguration.UploadPath, request.RoomId.ToString()),
                FileName = request.File.FileName,
                PathFileName = Path.Combine(Path.Combine(_fileConfiguration.UploadPath, request.RoomId.ToString()),request.File.FileName)
            });
            await _fileService.Save(Path.Combine(_fileConfiguration.UploadPath, request.RoomId.ToString()),request.File);

            return default;
        }
    }
}
