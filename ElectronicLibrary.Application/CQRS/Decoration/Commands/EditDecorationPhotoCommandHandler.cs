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

namespace ElectronicBookingSystem.Application.CQRS.Decoration.Commands
{
    public class EditDecorationPhotoCommandHandler : IRequestHandler<EditDecorationPhotoCommand>
    {
        private readonly IRepository<Domain.Entities.File> _repository;
        private readonly IFileService _fileService;
        private readonly FileConfiguration _fileConfiguration;

        public EditDecorationPhotoCommandHandler(IRepository<Domain.Entities.File> repository, IFileService fileService, FileConfiguration fileConfiguration)
        {
            _repository = repository;
            _fileService = fileService;
            _fileConfiguration = fileConfiguration;
        }

        public async Task<Unit> Handle(EditDecorationPhotoCommand request, CancellationToken cancellationToken)
        {
            await _repository.Save(new Domain.Entities.File
            {
                FileName = request.File.FileName,
                UploadPath = Path.Combine(_fileConfiguration.UploadPath,request.DecorationId.ToString()),
                PathFileName = Path.Combine(_fileConfiguration.UploadPath, request.DecorationId.ToString(),request.File.FileName),
                DecorationId = request.DecorationId
            });
            await _fileService.Save(Path.Combine(_fileConfiguration.UploadPath, request.DecorationId.ToString()), request.File);

            return default;
        }
    }
}
