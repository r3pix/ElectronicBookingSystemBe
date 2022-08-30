using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.File.Queries
{
    public class GetFileByIdQueryHandler : IRequestHandler<GetFileByIdQuery, (byte[], string)>
    {
        private readonly IRepository<ElectronicBookingSystem.Domain.Entities.File> _fileRepository;
        private readonly IFileService _fileService;

        public GetFileByIdQueryHandler(IRepository<ElectronicBookingSystem.Domain.Entities.File> fileRepository, IFileService fileService)
        {
            _fileRepository = fileRepository;
            _fileService = fileService;
        }

        public async Task<(byte[], string)> Handle(GetFileByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _fileRepository.GetById(request.Id);
            var bytes = await _fileService.ReadFileBytes(entity.PathFileName);

            return (bytes, entity.FileName);
        }
    }
}
