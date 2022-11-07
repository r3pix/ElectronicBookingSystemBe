using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Domain.Entities
{
    public class Opinion : BaseEntity<Guid>
    {
        public Guid RoomId { get; set; }
        public float Grade { get; set; }
        public Guid UserId { get; set; }
        public string Comment { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
