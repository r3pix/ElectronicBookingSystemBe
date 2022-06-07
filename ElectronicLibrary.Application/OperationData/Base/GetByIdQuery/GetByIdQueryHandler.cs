using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ElectronicLibrary.Infrastructure.Extensions;
using ElectronicLibrary.Persistance;
using ElectronicLibrary.Persistance.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ElectronicLibrary.Application.OperationData.Base.GetByIdQuery
{
    public abstract class GetByIdQueryHandler<TKey, TEntity, TQuery, TViewModel> : IRequestHandler<TQuery, Response<TViewModel>> where TEntity : BaseEntity<TKey>
        where TQuery : IGetByIdQuery<TKey, TViewModel> where TViewModel : class where TKey : struct
    {
        private readonly ElectronicLibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public DbSet<TEntity> DbSet;

        protected GetByIdQueryHandler(ElectronicLibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            DbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<Response<TViewModel>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var entity = await GetEntity(request);
            var result = _mapper.Map<TViewModel>(entity);
            return new Response<TViewModel>(result);
        }

        public virtual async Task<TEntity> GetEntity(TQuery request) =>
            await DbSet.FindAsync(request.Id);
    }
}
