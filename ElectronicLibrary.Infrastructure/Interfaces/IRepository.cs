using ElectronicLibrary.Persistance.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task Delete<TKey>(TKey id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById<TKey>(TKey id);
        Task<TEntity> Save(TEntity entity);
        Task<TEntity> Update<TKey, TModel>(TKey id, TModel model);
    }
}