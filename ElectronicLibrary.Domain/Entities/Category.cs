using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Domain.Entities
{
    public class Category : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public virtual IEnumerable<Room> Rooms { get; set; }
    }
}
