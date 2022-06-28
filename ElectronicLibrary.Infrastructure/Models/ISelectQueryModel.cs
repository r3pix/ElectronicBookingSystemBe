using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Extensions
{
    /// <summary>
    /// Interface for get for select query
    /// </summary>
    public interface ISelectQueryModel
    {
        /// <summary>
        /// Words to filter
        /// </summary>
        public string FilterWords { get; set; }
        //ublic 
    }
}
