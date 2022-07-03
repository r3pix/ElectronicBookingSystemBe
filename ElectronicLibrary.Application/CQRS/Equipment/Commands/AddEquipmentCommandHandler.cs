using AutoMapper;
using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Domain.Entities;
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

namespace ElectronicLibrary.Application.CQRS.Equipment.Commands
{
    public class AddEquipmentCommandHandler : IRequestHandler<AddEquipmentCommand>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IRepository<Domain.Entities.File> _fileRepository;
        private readonly IFileService _fileService;
        private readonly FileConfiguration _fileConfiguration;
        private readonly IMapper _mapper;

        public AddEquipmentCommandHandler(IEquipmentRepository equipmentRepository, IRepository<Domain.Entities.File> fileRepository, 
            IFileService fileService, IMapper mapper, FileConfiguration fileConfiguration)
        {
            _equipmentRepository = equipmentRepository;
            _fileRepository = fileRepository;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(AddEquipmentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Equipment>(request);
            entity = await _equipmentRepository.Save(entity);

            await _fileRepository.Save(new Domain.Entities.File()
            {
                UploadPath = Path.Combine(_fileConfiguration.UploadPath,entity.Id.ToString()),
                PathFileName = Path.Combine(_fileConfiguration.UploadPath,entity.Id.ToString(),request.File.Name),
                FileName = request.File.Name,
                EquipmentId = entity.Id
            });

            await _fileService.Save(Path.Combine(_fileConfiguration.UploadPath, entity.Id.ToString()),request.File);

            return default;
        }
    }
}
