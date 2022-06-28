using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Extensions
{
    /// <summary>
    /// Response model for pageable requests
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    public class PageableModel<T> where T : class
    {
        public PageableModel(IEnumerable<T> result, int count)
        {
            Result = result;
            Total = count;
        }
        /// <summary>
        /// List of records
        /// </summary>
        /// 
        public IEnumerable<T> Result { get; set; }
        /// <summary>
        /// Total count 
        /// </summary>
        public int Total { get; set; }
    }
}
