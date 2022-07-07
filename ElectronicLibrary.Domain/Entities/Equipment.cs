using ElectronicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Entities
{
    /// <summary>
    /// Entity class modelling equipment
    /// </summary>
    public class Equipment : BaseEntity<Guid>
    {
        /// <summary>
        /// Name of the equipment
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cost of the decoration
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Photo of equipment
        /// </summary>
        public virtual File File { get; set; }

        /// <summary>
        /// Reference to booking class
        /// </summary>
        public virtual IEnumerable<Booking> Bookings { get; set; }
    }
}
