using ElectronicLibrary.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Entities
{
    //pakiet obsługi
    public class Service : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public virtual IEnumerable<Booking> Bookings { get; set; }
    }
}
