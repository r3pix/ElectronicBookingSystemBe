﻿using AutoMapper;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Application.CQRS.Equipment.Queries;
using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Infrastructure.Extensions;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Repositories
{
    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(ElectronicBookingSystemDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<SelectModel<Guid>>> GetForSelect(GetEquipmentForSelectQuery request) =>
           await _dbContext.Equipment.GetForSelect(request.FilterWords).ToListAsync();

        public async Task<Equipment> GetById(Guid Id) =>
            await _dbContext.Equipment.Include(x => x.Files).FirstOrDefaultAsync(x => x.Id == Id);
    }
}
