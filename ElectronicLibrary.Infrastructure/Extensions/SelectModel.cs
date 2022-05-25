using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Extensions
{
    public class SelectModel<T>
    {
        public T Id { get; set; }
        public string Label{ get; set; }
    }
}
