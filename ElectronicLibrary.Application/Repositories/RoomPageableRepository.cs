using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Extensions;
using ElectronicBookingSystem.Infrastructure.Models.Category;
using ElectronicBookingSystem.Infrastructure.Models.Room;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Application.Repositories
{
    public class RoomPageableRepository : PageableRepository<GetPageableRoomsFilter, Room>, IRoomPageableRepository
    {
        public RoomPageableRepository(ElectronicBookingSystemDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Room> Filter(GetPageableRoomsFilter filter) =>
            FilterBySearchTerm(filter.SearchTerm);

        private IQueryable<Room> FilterBySearchTerm(string searchTerm)
        {
            var query = dbSet.Include(x=>x.Category).Include(x=>x.Files).AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var splitWords = searchTerm.Trim().Split(" ");
                foreach(var word in splitWords)
                {
                    var wordLike = word.ToLikeExpression();
                    query = query.Where(x => EF.Functions.Like(x.Category.Name, wordLike) || EF.Functions.Like(x.Description, wordLike) || EF.Functions.Like(x.Name, wordLike));
                }
            }
            return query;
        }
    }
}
