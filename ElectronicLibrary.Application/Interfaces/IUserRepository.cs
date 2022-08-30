using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Application.Interfaces;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        new Task<User> GetByPredicate(Expression<Func<User, bool>> expression);
    }
}