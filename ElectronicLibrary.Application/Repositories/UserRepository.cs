using AutoMapper;
using ElectronicLibrary.Domain.Entities;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ElectronicBookingSystemDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override async Task<User> GetByPredicate(Expression<Func<User, bool>> expression) =>
            await _dbContext.Users.Include(x => x.Role).Include(x=>x.Identity).FirstOrDefaultAsync(expression);
    }
}
