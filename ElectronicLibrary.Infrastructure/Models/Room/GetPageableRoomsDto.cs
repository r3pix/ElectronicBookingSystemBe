using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Models.Room
{
    public class GetPageableRoomsDto
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string SearchTerm { get; set; }
        public string OrderBy { get; set; }
        public bool Desc { get; set; }
    }
}
