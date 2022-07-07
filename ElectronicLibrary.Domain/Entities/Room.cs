using ElectronicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Entities
{
    /// <summary>
    /// Entity class modelling room
    /// </summary>
    public class Room : BaseEntity<Guid>
    {
        /// <summary>
        /// Name of the room
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Maximal count of places
        /// </summary>
        public int TotalMaxPlaces { get; set; }

        /// <summary>
        /// Maximal count of tables
        /// </summary>
        public int TotalMaxTables { get; set; }

        /// <summary>
        /// Width of the room
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of the room
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Length of the room
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Short room description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Cost of the room
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Picture of the room
        /// </summary>
        public virtual File File { get; set; }

        /// <summary>
        /// Reference to booking class
        /// </summary>
        public virtual IEnumerable<Booking> Bookings { get; set; }
    }
}
