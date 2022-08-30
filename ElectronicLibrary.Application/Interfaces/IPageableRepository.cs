
using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Interfaces
{
    public interface IPageableRepository<TFilter, TEntity>
        where TFilter : class
        where TEntity : BaseEntity
    {
        Task<(IEnumerable<TEntity>, int)> GetPageable(TFilter filter, IPageableQueryModel page);
    }
}