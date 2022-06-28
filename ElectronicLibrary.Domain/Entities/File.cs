using ElectronicLibrary.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Entities
{
    /// <summary>
    /// Entity class modelling files
    /// </summary>
    public class File : BaseEntity<Guid>
    {
        /// <summary>
        /// Name of the file
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Upload path of the file
        /// </summary>
        public string UploadPath { get; set; }

        /// <summary>
        /// Upload path combined with filename (full path)
        /// </summary>
        public string PathFileName { get; set; }

        /// <summary>
        /// Optional reference to decoration class
        /// </summary>
        public Guid? DecorationId { get; set; }

        /// <summary>
        /// Optional reference to equipment class
        /// </summary>
        public Guid? EquipmentId { get; set; }

        /// <summary>
        /// Optional reference to room class
        /// </summary>
        public Guid? RoomId { get; set; }

        /// <summary>
        /// Optional reference to decoration class
        /// </summary>
        public virtual Decoration Decoration { get; set; }

        /// <summary>
        /// Optional reference to decoration class
        /// </summary>
        public virtual Equipment Equipment { get; set; }

        /// <summary>
        /// Optional reference to room class
        /// </summary>
        public virtual Room Room { get; set; }
    }
}
