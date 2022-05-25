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

namespace ElectronicLibrary.Application.OperationData.Base.GetFilteredQuery
{
    public abstract class GetFilteredQueryHandler<TKey,TEntity, TQuery> : IRequestHandler<TQuery, Response<List<SelectModel<TKey>>>> 
        where TQuery : IGetFilteredQuery<TKey> where TEntity:BaseEntity<TKey> where TKey : struct
    {
        private readonly ElectronicLibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        private DbSet<TEntity> DbSet;

        protected GetFilteredQueryHandler(ElectronicLibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            DbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<Response<List<SelectModel<TKey>>>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var result = GetResult(request);
            return new Response<List<SelectModel<TKey>>>(result);
        }

        protected abstract List<SelectModel<TKey>> GetResult(TQuery request);
    }
}
