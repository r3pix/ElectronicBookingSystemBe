﻿using AutoMapper;
using ElectronicLibrary.Infrastructure.Models;
using ElectronicLibrary.Application.Repositories;
using ElectronicLibrary.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ElectronicLibrary.Application.Interfaces;

namespace ElectronicLibrary.Application.CQRS.Decoration.Commands
{
    /// <summary>
    /// Class handling AddDecoration Request
    /// </summary>
    public class AddDecorationCommandHandler : IRequestHandler<AddDecorationCommand>
    {
        private readonly IDecorationRepository _decorationRepository;
        private readonly IRepository<ElectronicBookingSystem.Domain.Entities.File> _fileRepository;
        private readonly FileConfiguration _fileConfiguration;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public AddDecorationCommandHandler(IDecorationRepository decorationRepository,IRepository<ElectronicBookingSystem.Domain.Entities.File> fileRepository,
            FileConfiguration fileConfiguration,IFileService fileService ,IMapper mapper)
        {
            _decorationRepository = decorationRepository;
            _fileRepository = fileRepository;
            _fileConfiguration = fileConfiguration;
            _fileService = fileService;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public async Task<Unit> Handle(AddDecorationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _decorationRepository.Save(new ElectronicBookingSystem.Domain.Entities.Decoration()
            {
                Name = request.Name,
                Cost = request.Cost
            });

            await _fileRepository.Save(new ElectronicBookingSystem.Domain.Entities.File()
            {
                FileName = request.File.FileName,
                UploadPath = Path.Combine(_fileConfiguration.UploadPath,entity.Id.ToString()),
                PathFileName = Path.Combine(_fileConfiguration.UploadPath,entity.Id.ToString(),request.File.FileName),
                DecorationId = entity.Id
            });

            await _fileService.Save(Path.Combine(_fileConfiguration.UploadPath,entity.Id.ToString()),request.File);

            return default;

        }
    }
}
