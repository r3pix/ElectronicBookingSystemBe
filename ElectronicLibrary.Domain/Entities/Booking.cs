using ElectronicLibrary.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Entities
{
    public class Booking : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public int TotalPlaces { get; set; }
        public int TotalTables { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Guid DecorationId { get; set; }
        public Guid EquipmentId { get; set; }
        public Guid RoomId { get; set; }
        public Guid ServiceId { get; set; }
        public Guid UserId { get; set; }

        public virtual Decoration Decoration { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Room Room { get; set; }    
        public virtual Service Service { get; set; }
        public virtual User User { get; set; }
    }
}
