using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Extensions;
using ElectronicBookingSystem.Infrastructure.Models.User;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Repositories
{
    public class UserPageableRepository : PageableRepository<GetPageableUsersFilter, User>, IUserPageableRepository
    {
        public UserPageableRepository(ElectronicBookingSystemDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<User> Filter(GetPageableUsersFilter filter) =>
            FilterBySearchTerm(filter.SearchTerm);

        private IQueryable<User> FilterBySearchTerm(string searchTerm)
        {
            var query = dbSet.Include(x => x.Role).Include(x => x.Identity).Include(x => x.Address).AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var splitWords = searchTerm.Trim().Split(" ");
                foreach(var word in splitWords)
                {
                    query = query.Where(x=> EF.Functions.Like(x.Email, word.ToLikeExpression()) || EF.Functions.Like(x.Identity.Name,word.ToLikeExpression()) || EF.Functions.Like(x.Identity.LastName, word.ToLikeExpression())
                    || EF.Functions.Like(x.Role.Name,word.ToLikeExpression()));
                }
            }
            return query;
        }
    }
}
