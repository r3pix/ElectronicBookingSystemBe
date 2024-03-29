﻿using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Extensions;
using ElectronicLibrary.Infrastructure.Extensions;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Repositories
{
    public abstract class PageableRepository<TFilter, TEntity> : IPageableRepository<TFilter, TEntity> where TEntity : BaseEntity where TFilter : class
    {
        private readonly ElectronicBookingSystemDbContext _dbContext;
        protected DbSet<TEntity> dbSet;

        public PageableRepository(ElectronicBookingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<(IEnumerable<TEntity>, int)> GetPageable(TFilter filter, IPageableQueryModel page) =>
            await Filter(filter).Page(page);

        protected virtual IQueryable<TEntity> Filter(TFilter filter) =>
            dbSet;
    }
}
