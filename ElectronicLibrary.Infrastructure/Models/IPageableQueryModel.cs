using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Extensions
{
    /// <summary>
    /// Interface containing pageable model 
    /// </summary>
    public interface IPageableQueryModel
    {
        /// <summary>
        /// Size of the page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Number of the page
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Field to order by
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Direction of sort
        /// </summary>
        public bool Desc { get; set; }

        /// <summary>
        /// Words to filter by
        /// </summary>
        public string SearchTerm { get; set; }
    }
}
