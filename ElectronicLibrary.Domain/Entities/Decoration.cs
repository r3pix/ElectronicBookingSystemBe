using ElectronicLibrary.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Entities
{
    public class Decoration : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public Guid FileId { get; set; }

        public virtual File File { get; set; }
        public virtual IEnumerable<Booking> Bookings { get; set; }
    }
}
