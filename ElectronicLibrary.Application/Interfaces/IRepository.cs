using ElectronicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Interfaces
{
    /// <summary>
    /// Interface for Repository class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Deletes the entity
        /// </summary>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <param name="id">Id of the entity</param>
        /// <returns></returns>
        Task Delete<TKey>(TKey id);

        /// <summary>
        /// Reads all entities
        /// </summary>
        /// <returns>IEnumerable<typeparamref name="TEntity"/></returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Gets entity by Id
        /// </summary>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <param name="id">Id of the entity</param>
        /// <returns>entity</returns>
        Task<TEntity> GetById<TKey>(TKey id);

        /// <summary>
        /// Saves provided entity
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Saved entity</returns>
        Task<TEntity> Save(TEntity entity);

        /// <summary>
        /// Updates the entity with provided Id and data model
        /// </summary>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <typeparam name="TModel">Type of model</typeparam>
        /// <param name="id">Id of the entity</param>
        /// <param name="model">Update data</param>
        /// <returns>Updated entity</returns>
        Task<TEntity> Update<TKey, TModel>(TKey id, TModel model);

        Task<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> expression);
    }
}