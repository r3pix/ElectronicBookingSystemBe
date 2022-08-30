using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Domain.Entities
{
    /// <summary>
    /// Entity class modelling signle booking
    /// </summary>
    public class Booking : BaseEntity<Guid>
    {
        /// <summary>
        /// Name of the booking
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Total places reserved
        /// </summary>
        public int TotalPlaces { get; set; }

        /// <summary>
        /// Total tables reserved
        /// </summary>
        public int TotalTables { get; set; }

        /// <summary>
        /// Total cost of booking
        /// </summary>
        public float TotalCost { get; set; }

        /// <summary>
        /// Date of reservation
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Description of event type
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Reference to decoration entity
        /// </summary>
        public Guid DecorationId { get; set; }

        /// <summary>
        /// Reference to equipment entity
        /// </summary>
        public Guid EquipmentId { get; set; }

        /// <summary>
        /// Reference to room entity
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Reference to service entity
        /// </summary>
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Reference to user entity
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Reference to decoration entity
        /// </summary>
        public virtual Decoration Decoration { get; set; }

        /// <summary>
        /// Reference to equipment entity
        /// </summary>
        public virtual Equipment Equipment { get; set; }

        /// <summary>
        /// Reference to room entity
        /// </summary>
        public virtual Room Room { get; set; }

        /// <summary>
        /// Reference to service entity
        /// </summary>
        public virtual Service Service { get; set; }

        /// <summary>
        /// Reference to user entity
        /// </summary>
        public virtual User User { get; set; }
    }
}
