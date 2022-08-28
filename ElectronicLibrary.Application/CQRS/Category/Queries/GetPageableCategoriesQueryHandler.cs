using AutoMapper;
using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Infrastructure.Models.Category;
using ElectronicLibrary.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.CQRS.Category.Queries
{
    public class GetPageableCategoriesQueryHandler : IRequestHandler<GetPageableCategoriesQuery, Response<PageableModel<CategoryListModel>>>
    {
        private readonly ICategoryPageableRepository _repository;
        private readonly IMapper _mapper;

        public GetPageableCategoriesQueryHandler(ICategoryPageableRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<PageableModel<CategoryListModel>>> Handle(GetPageableCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetPageable(request.Filter, request.Page);
            var mappedEntities = _mapper.Map<IEnumerable<CategoryListModel>>(result.Item1);

            return new Response<PageableModel<CategoryListModel>>(new PageableModel<CategoryListModel>(mappedEntities, result.Item2));
        }
    }
}
