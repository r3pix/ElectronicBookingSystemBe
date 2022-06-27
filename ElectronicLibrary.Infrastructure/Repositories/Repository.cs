using ElectronicLibrary.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicLibrary.Persistance;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ElectronicLibrary.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ElectronicLibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public Repository(ElectronicLibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TEntity> Save(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update<TKey, TModel>(TKey id, TModel model)
        {
            var existingEntity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (existingEntity == null)
            {
                throw new Exception("Entity With provided Id does not exist");
            }
            _mapper.Map(model, existingEntity);
            await _dbContext.SaveChangesAsync();

            return existingEntity;
        }

        public async Task Delete<TKey>(TKey id)
        {
            var existingEntity = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Remove(existingEntity); //gdyby nie działało to .set<>()
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var entities = await _dbContext.Set<TEntity>().ToListAsync();
            return entities;
        }

        public async Task<TEntity> GetById<TKey>(TKey id) =>
            await _dbContext.Set<TEntity>().FindAsync(id);

    }
}
