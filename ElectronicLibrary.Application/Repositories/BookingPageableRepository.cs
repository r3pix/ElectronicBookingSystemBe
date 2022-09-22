using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Extensions;
using ElectronicBookingSystem.Infrastructure.Interfaces;
using ElectronicBookingSystem.Infrastructure.Models.Booking;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Repositories
{
    public class BookingPageableRepository : PageableRepository<GetPageableBookingsQueryFilter, Booking>, IBookingPageableRepository
    {
        private readonly ICurrentUserService _currentUserService;

        public BookingPageableRepository(ElectronicBookingSystemDbContext dbContext, ICurrentUserService currentUserService) : base(dbContext)
        {
            _currentUserService = currentUserService;
        }

        protected override IQueryable<Booking> Filter(GetPageableBookingsQueryFilter filter)
        {
            var query = FilterBySearchTerm(filter.SearchTerm);
            query = FilterByUserRole(query);
            return query;
        }

        private IQueryable<Booking> FilterByUserRole(IQueryable<Booking> query)
        {
            if (_currentUserService.Role == "User")
            {
                return query.Where(x => x.UserId.ToString() == _currentUserService.Id);
            }
            else if (_currentUserService.Role == "Admin")
            {
                return query;
            }
            else
                throw new Exception("User does have permission to get this data");
        }

        private IQueryable<Booking> FilterBySearchTerm(string searchTerm)
        {
            var query = dbSet.Include(x=>x.Decoration).Include(x=>x.Service).Include(x=>x.User).ThenInclude(x=>x.Identity).Include(x=>x.User.Role).Include(x=>x.Room)
                .Include(x=>x.Equipment).AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var splitWords = searchTerm.Trim().Split(' ');
                foreach(var word in splitWords)
                {
                    query = query.Where(x=> EF.Functions.Like(x.Decoration.Name, word.ToLikeExpression()) || 
                    EF.Functions.Like(x.Service.Name,word.ToLikeExpression()) ||
                    EF.Functions.Like(x.User.Identity.Name,word.ToLikeExpression()) ||
                    EF.Functions.Like(x.User.Identity.LastName, word.ToLikeExpression()) ||
                    EF.Functions.Like(x.Room.Name, word.ToLikeExpression()) ||
                    EF.Functions.Like(x.Equipment.Name, word.ToLikeExpression()) ||
                    EF.Functions.Like(x.Name, word.ToLikeExpression()) ||
                    EF.Functions.Like(x.TotalCost.ToString(), word.ToLikeExpression()));
                }
            }

            return query;
        }
    }
}
