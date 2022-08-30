using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Domain.Entities
{

    /// <summary>
    /// Entity class modelling User Identity
    /// </summary>
    public class Identity : BaseEntity<Guid>
    {
        /// <summary>
        /// First name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Reference to user class
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Reference to user class
        /// </summary>
        public virtual User User { get; set; }
    }
}
