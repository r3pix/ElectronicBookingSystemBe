using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Extensions
{
    /// <summary>
    /// Model for get for select requests
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class SelectModel<TKey> where TKey : struct
    {
        /// <summary>
        /// Entity key
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// Select label
        /// </summary>
        public string Label{ get; set; }
    }
}
