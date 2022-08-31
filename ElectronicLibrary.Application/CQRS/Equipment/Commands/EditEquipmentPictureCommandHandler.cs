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

namespace ElectronicBookingSystem.Application.CQRS.Equipment.Commands
{
    public class EditEquipmentPictureCommandHandler : IRequestHandler<EditEquipmentPictureCommand>
    {
        private readonly IRepository<Domain.Entities.File> _repository;
        private readonly IFileService _fileService;
        private readonly FileConfiguration _fileConfiguration;

        public EditEquipmentPictureCommandHandler(IRepository<Domain.Entities.File> repository, IFileService fileService, FileConfiguration fileConfiguration)
        {
            _repository = repository;
            _fileService = fileService;
            _fileConfiguration = fileConfiguration;
        }

        public async Task<Unit> Handle(EditEquipmentPictureCommand request, CancellationToken cancellationToken)
        {

            await _repository.Save(new Domain.Entities.File
            {
                FileName = request.File.FileName,
                UploadPath = Path.Combine(_fileConfiguration.UploadPath, request.EquipmentId.ToString()),
                PathFileName = Path.Combine(_fileConfiguration.UploadPath, request.EquipmentId.ToString(), request.File.FileName),
                EquipmentId = request.EquipmentId
            });
           
            await _fileService.Save(Path.Combine(_fileConfiguration.UploadPath, request.EquipmentId.ToString()), request.File);

            return default;
        }
    }
}
