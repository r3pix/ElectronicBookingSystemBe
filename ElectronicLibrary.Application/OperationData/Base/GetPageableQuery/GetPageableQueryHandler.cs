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

namespace ElectronicLibrary.Application.OperationData.Base.GetPageableQuery
{
    public abstract class GetPageableQueryHandler<TKey, TEntity, TQuery, TViewModel> : IRequestHandler<TQuery,Response<PageableModel<TViewModel>>> 
        where TQuery : IGetPageableQuery<TViewModel>  where TEntity : BaseEntity<TKey> where TViewModel : class where TKey : struct
    {
        private readonly ElectronicLibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        private DbSet<TEntity> DbSet;

        protected GetPageableQueryHandler(ElectronicLibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            DbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<Response<PageableModel<TViewModel>>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var result = await GetResult(request);
            return new Response<PageableModel<TViewModel>>(new PageableModel<TViewModel>(result.Item1, result.Item2));
        }

        protected async Task<(IEnumerable<TViewModel>, int)> GetResult(TQuery request)
        {
            var queryTotal = GetSearchTermFilteredQuery(request);
            var query = GetOrderBy(queryTotal, request.OrderBy, request.Desc);

            query = query.Skip((request.PageNumber - 1) * request.PageSize);
            query = query.Take(request.PageSize);

            var result = await query.ToListAsync();
            var mappedResult = _mapper.Map<IEnumerable<TViewModel>>(result);

            return (mappedResult, await queryTotal.CountAsync());

        }

        protected IQueryable<TEntity> GetSearchTermFilteredQuery(TQuery request)
        {
            var query = GetFilteredQuery(request);
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                var filterArray = request.SearchTerm.Trim().Split(" ");
                foreach (var word in filterArray)
                {
                    FilterExpression(ref query, word);
                }
            }
            return query;
        }

        protected abstract IQueryable<TEntity> GetOrderBy(IQueryable<TEntity> query, string orderBy, bool desc);

        protected abstract void FilterExpression(ref IQueryable<TEntity> query, string word);

        protected virtual IQueryable<TEntity> GetFilteredQuery(TQuery request)
            => DbSet.AsQueryable();
    }
}
