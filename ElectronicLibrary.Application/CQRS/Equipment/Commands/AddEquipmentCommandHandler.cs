using AutoMapper;
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

namespace ElectronicLibrary.Application.CQRS.Equipment.Commands
{
    public class AddEquipmentCommandHandler : IRequestHandler<AddEquipmentCommand>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IRepository<ElectronicBookingSystem.Domain.Entities.File> _fileRepository;
        private readonly IFileService _fileService;
        private readonly FileConfiguration _fileConfiguration;
        private readonly IMapper _mapper;

        public AddEquipmentCommandHandler(IEquipmentRepository equipmentRepository, IRepository<ElectronicBookingSystem.Domain.Entities.File> fileRepository, 
            IFileService fileService, IMapper mapper, FileConfiguration fileConfiguration)
        {
            _equipmentRepository = equipmentRepository;
            _fileRepository = fileRepository;
            _fileService = fileService;
            _mapper = mapper;
            _fileConfiguration = fileConfiguration;
        }

        public async Task<Unit> Handle(AddEquipmentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ElectronicBookingSystem.Domain.Entities.Equipment>(request);
            entity = await _equipmentRepository.Save(entity);

            await _fileRepository.Save(new ElectronicBookingSystem.Domain.Entities.File()
            {
                UploadPath = Path.Combine(_fileConfiguration.UploadPath,entity.Id.ToString()),
                PathFileName = Path.Combine(_fileConfiguration.UploadPath,entity.Id.ToString(),request.File.FileName),
                FileName = request.File.FileName,
                EquipmentId = entity.Id
            });

            await _fileService.Save(Path.Combine(_fileConfiguration.UploadPath, entity.Id.ToString()),request.File);

            return default;
        }
    }
}
