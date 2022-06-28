using ElectronicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Extensions
{
    public static class QueryableRoomExtensions
    {
        public static IQueryable<SelectModel<Guid>> GetForSelect(this IQueryable<Room> query, ISelectQueryModel request) =>
            query.Filter(request.FilterWords).Select(x=> new SelectModel<Guid> { Id = x.Id, Label = x.Name });

        public static IQueryable<Room> Filter(this IQueryable<Room> query, string filterWords)
        {
            if (!string.IsNullOrEmpty(filterWords))
            {
                var filterArray = filterWords.Trim().Split(" ");
                foreach (var word in filterArray)
                    query = query.Where(x => x.Name.Contains(word) || x.Description.Contains(word) 
                    || x.TotalMaxPlaces.ToString().Contains(word) || x.TotalMaxTables.ToString().Contains(word));
                    
            }
            return query;
        }
    }
}
