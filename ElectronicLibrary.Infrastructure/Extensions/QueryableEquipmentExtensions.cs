using ElectronicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Extensions
{
    public static class QueryableEquipmentExtensions
    {
        public static IQueryable<SelectModel<Guid>> GetForSelect(this IQueryable<Equipment> query, string filterWords) =>
            query.Filter(filterWords).Select(x => new SelectModel<Guid>() { Id = x.Id, Label = x.Name });

        public static IQueryable<Equipment> Filter(this IQueryable<Equipment> query, string filterWords)
        {
            if (!string.IsNullOrEmpty(filterWords))
            {
                var filterArray = filterWords.Trim().Split(' ');
                foreach (var word in filterArray)
                    query = query.Where(x => x.Name.Contains(word));
            }
            return query;
        }
    }
}
