using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Models.Room
{
    public class RoomListModel
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
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }

        public Guid FileId { get; set; }


    }
}
