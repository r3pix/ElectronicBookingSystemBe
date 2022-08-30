using ElectronicBookingSystem.Application.CQRS.Category.Queries;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<SelectModel<Guid>>> GetForSelect(GetCategoriesForSelectQuery query);
    }
}