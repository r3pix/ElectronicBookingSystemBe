using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ElectronicLibrary.Infrastructure.Extensions;
using ElectronicLibrary.Persistance;
using ElectronicLibrary.Persistance.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ElectronicLibrary.Application.OperationData.Base.AddCommandWithResult
{
    public abstract class AddCommandWithResultHandler<TKey, TEntity, TCommand> : IRequestHandler<TCommand, Response<TKey>> where TCommand : IAddCommandWithResult<TKey>
        where TEntity : BaseEntity<TKey> where TKey : struct
    {
        private readonly ElectronicLibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        private DbSet<TEntity> DbSet;

        protected AddCommandWithResultHandler(ElectronicLibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            DbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<Response<TKey>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request);
            await DbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return new Response<TKey>(entity.Id);
        }
    }
}
