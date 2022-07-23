using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Models.Decoration
{
    public class DecorationModel
    {
        /// <summary>
        /// Name of the decoration
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cost of the decoration
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Photo of Decoration
        /// </summary>
        public string FileAddress { get; set; }
    }
}
