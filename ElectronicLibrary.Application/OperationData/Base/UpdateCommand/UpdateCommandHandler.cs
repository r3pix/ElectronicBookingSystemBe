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

namespace ElectronicLibrary.Application.OperationData.Base.UpdateCommand
{
    internal abstract class UpdateCommandHandler<TKey,TEntity,TCommand> : IRequestHandler<TCommand> 
        where TCommand : IUpdateCommand<TKey> where TEntity : BaseEntity<TKey> where TKey : struct
    {
        private readonly ElectronicLibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        private DbSet<TEntity> DbSet;

        protected UpdateCommandHandler(ElectronicLibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            DbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = await GetEntity(request); //jak mapper podswietla to oznacza ze nie dalem awaita
            _mapper.Map(request, entity);
            await _dbContext.SaveChangesAsync();
            return default;
        }

        public virtual async Task<TEntity> GetEntity(TCommand request) 
            => await DbSet.FindAsync(request.Id);
        
    }
}
