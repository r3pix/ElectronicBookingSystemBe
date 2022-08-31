using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Models.Service
{
    public class ServiceListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public string Description { get; set; }
    }
}
