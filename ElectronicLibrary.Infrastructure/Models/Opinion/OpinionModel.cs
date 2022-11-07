using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Models.Opinion
{
    public class OpinionModel
    {
        public float Grade { get; set; }
        public string Comment { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
