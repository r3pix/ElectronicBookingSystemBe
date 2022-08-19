using AutoMapper;
using ElectronicLibrary.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Category.Commands
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand>
    {
        private readonly IRepository<Domain.Entities.Category> _categoryRepository;
        private readonly IMapper _mapper;

        public AddCategoryCommandHandler(IRepository<Domain.Entities.Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Category>(request);
            await _categoryRepository.Save(entity);
            return default;
        }
    }
}
