using ElectronicBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Domain.Entities
{
    /// <summary>
    /// Entity class modelling user roles
    /// </summary>
    public class Role : BaseEntity<Guid>
    {
        /// <summary>
        /// Name of the role
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Reference to user class
        /// </summary>
        public virtual IEnumerable<User> Users { get; set; }

    }
}
