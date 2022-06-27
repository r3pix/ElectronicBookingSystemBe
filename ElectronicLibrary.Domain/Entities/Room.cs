using ElectronicLibrary.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Entities
{
    public class Room : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public int TotalMaxPlaces { get; set; }
        public int TotalMaxTables { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Guid FileId { get; set; }

        public virtual File File { get; set; }
        public virtual IEnumerable<Booking> Bookings { get; set; }
    }
}
