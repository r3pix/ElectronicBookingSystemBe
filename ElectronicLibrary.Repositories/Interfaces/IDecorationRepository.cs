using ElectronicLibrary.Application.CQRS.Decoration.Queries;
using ElectronicLibrary.Domain.Entities;
using ElectronicLibrary.Infrastructure.Extensions;
using ElectronicLibrary.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicLibrary.Repositories.Interfaces
{
    public interface IDecorationRepository : IRepository<Decoration>
    {
        Task<IEnumerable<SelectModel<Guid>>> GetForSelect(GetDecorationsForSelectQuery request);
    }
}