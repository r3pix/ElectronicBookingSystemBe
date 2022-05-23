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
    public class AddCommandHandler<TKey, TEntity, TCommand> : IRequestHandler<TCommand> where TCommand : IAddCommand<TKey> where TEntity : BaseEntity<TKey> where TKey : struct
    {
        private readonly IMapper _mapper;
        private readonly ElectronicLibraryDbContext _dbContext;
        private readonly DbSet<TEntity> DbSet;

        public AddCommandHandler(IMapper mapper, ElectronicLibraryDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public virtual async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
