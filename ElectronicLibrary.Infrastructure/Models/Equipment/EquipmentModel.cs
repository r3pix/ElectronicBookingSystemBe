using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Models.Equipment
{
    public class EquipmentModel
    {
        /// <summary>
        /// Name of the equipment
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cost of the decoration
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Photo of equipment
        /// </summary>
        public Guid FileId { get; set; }
    }
}
