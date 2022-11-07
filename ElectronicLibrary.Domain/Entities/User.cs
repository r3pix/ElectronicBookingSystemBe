using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Domain.Entities
{
    /// <summary>
    /// Entity class modelling user 
    /// </summary>
    public class User : BaseEntity<Guid>
    {
        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Hash of the user password
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Reference to role entity
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Role of the user 
        /// </summary>
        public virtual Role Role { get; set; }

        /// <summary>
        /// Identity of the user 
        /// </summary>
        public virtual Identity Identity { get; set; }

        /// <summary>
        /// Address of the user 
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Reference to the booking class
        /// </summary>
        public virtual IEnumerable<Booking> Bookings { get; set; }
        public virtual IEnumerable<Opinion> Opinions { get; set; }
    }
}
