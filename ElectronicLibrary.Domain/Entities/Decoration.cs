using ElectronicLibrary.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Entities
{
    /// <summary>
    /// Entity class modelling decoration
    /// </summary>
    public class Decoration : BaseEntity<Guid>
    {
        /// <summary>
        /// Name of the decoration
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cost of the decoration
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Photo of Decoration
        /// </summary>
        public virtual File File { get; set; }

        /// <summary>
        /// Reference to booking class
        /// </summary>
        public virtual IEnumerable<Booking> Bookings { get; set; }
    }
}
