using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ElectronicLibrary.Persistance;
using ElectronicLibrary.Persistance.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ElectronicLibrary.Application.OperationData.Base.AddCommand
{
    public abstract class AddCommandHandler<TKey, TEntity, TCommand> : IRequestHandler<TCommand> where TCommand : IAddCommand<TKey> where TEntity : BaseEntity<TKey> where TKey : struct
    {
        private readonly IMapper _mapper;
        private readonly ElectronicLibraryDbContext _dbContext;
        private DbSet<TEntity> DbSet;

        protected AddCommandHandler(IMapper mapper, ElectronicLibraryDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request);
            await DbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return default;
        }
    }
}
