using ElectronicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Extensions
{
    public static class QueryableServicesExtensions
    {
        public static IQueryable<SelectModel<Guid>> GetForSelect(this IQueryable<Service> query, string filterWords) =>
            query.Filter(filterWords).Select(x=> new SelectModel<Guid>() { Id=x.Id, Label = x.Name });

        public static IQueryable<Service> Filter(this IQueryable<Service> query, string filterWords)
        {
            if(!string.IsNullOrEmpty(filterWords))
            {
                var filterArray = filterWords.Trim().Split(" ");
                foreach (var word in filterArray)
                    query = query.Where(x => x.Name.Contains(word) || x.Description.Contains(word));
            }
            return query;
        }
    }
}
