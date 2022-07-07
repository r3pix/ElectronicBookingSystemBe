using ElectronicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicLibrary.Persistance;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ElectronicLibrary.Application.Repositories;
using ElectronicLibrary.Application.Interfaces;
using System.Linq.Expressions;

namespace ElectronicLibrary.Application.Repositories
{
    /// <summary>
    /// Generic repository containing base actions
    /// </summary>
    /// <typeparam name="TEntity">Entity to operatre</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ElectronicBookingSystemDbContext _dbContext;
        protected readonly IMapper _mapper;

        public Repository(ElectronicBookingSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Saves provided entity
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Saved entity</returns>
        public virtual async Task<TEntity> Save(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates the entity with provided Id and data model
        /// </summary>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <typeparam name="TModel">Type of model</typeparam>
        /// <param name="id">Id of the entity</param>
        /// <param name="model">Update data</param>
        /// <returns>Updated entity</returns>
        public virtual async Task<TEntity> Update<TKey, TModel>(TKey id, TModel model)
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

        /// <summary>
        /// Updates the entity
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> entity</param>
        /// <returns>The <see cref="TEntity"/> entity</returns>
        public virtual async Task<TEntity> Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Deletes the entity
        /// </summary>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <param name="id">Id of the entity</param>
        /// <returns></returns>
        public virtual async Task Delete<TKey>(TKey id)
        {
            var existingEntity = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Remove(existingEntity); //gdyby nie działało to .set<>()
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Reads all entities
        /// </summary>
        /// <returns>IEnumerable<typeparamref name="TEntity"/></returns>
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var entities = await _dbContext.Set<TEntity>().ToListAsync();
            return entities;
        }

        /// <summary>
        /// Gets entity by Id
        /// </summary>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <param name="id">Id of the entity</param>
        /// <returns>entity</returns>
        public virtual async Task<TEntity> GetById<TKey>(TKey id) =>
            await _dbContext.Set<TEntity>().FindAsync(id);



        public virtual async Task<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> expression) =>
            await _dbContext.Set<TEntity>().Where(expression).FirstOrDefaultAsync();

    }
}
