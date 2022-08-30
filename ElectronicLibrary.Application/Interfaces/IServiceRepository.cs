using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Application.CQRS.Service.Queries;
using ElectronicLibrary.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<IEnumerable<SelectModel<Guid>>> GetForSelect(GetServicesForSelectQuery request);
    }
}