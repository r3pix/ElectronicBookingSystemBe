using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Extensions
{
    public class PageableModel<T>
    {
        public List<T> Result { get; set; }
        public int Total { get; set; }
    }
}
