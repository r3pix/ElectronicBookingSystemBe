using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Extensions
{
    public class PageableModel<T> where T : class
    {
        public PageableModel(IEnumerable<T> result, int count)
        {
            Result = result;
            Total = count;
        }

        public IEnumerable<T> Result { get; set; }
        public int Total { get; set; }
    }
}
