using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Models.Room
{
    public class GetMainPageRoomsFilter
    {
        public string SearchTerm { get; set; }
        public List<Guid> CategoryIds { get; set; }
    }
}
