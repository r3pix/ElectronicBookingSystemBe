using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Domain.Entities
{
    /// <summary>
    /// Entity class modelling service
    /// </summary>
    //pakiet obsługi
    public class Service : BaseEntity<Guid>
    {
        /// <summary>
        /// Name of the service
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the service
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Cost of the Service
        /// </summary>
        public float Cost { get; set; }


        /// <summary>
        /// Reference to booking class
        /// </summary>
        public virtual IEnumerable<Booking> Bookings { get; set; }
    }
}
