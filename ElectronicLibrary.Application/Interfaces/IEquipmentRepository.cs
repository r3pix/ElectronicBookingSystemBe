﻿using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Application.CQRS.Equipment.Queries;
using ElectronicLibrary.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Interfaces
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
        Task<IEnumerable<SelectModel<Guid>>> GetForSelect(GetEquipmentForSelectQuery request);
        Task<Equipment> GetById(Guid Id);
    }
}