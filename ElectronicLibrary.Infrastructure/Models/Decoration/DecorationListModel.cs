using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Models.Decoration
{
    public class DecorationListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid FileId { get; set; }
        public float Cost { get; set; }
    }
}
