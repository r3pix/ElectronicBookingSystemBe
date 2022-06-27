using ElectronicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Identity Identity { get; set; }
        public virtual Address Address { get; set; }

        public virtual IEnumerable<Booking> Bookings { get; set; }
    }
}
