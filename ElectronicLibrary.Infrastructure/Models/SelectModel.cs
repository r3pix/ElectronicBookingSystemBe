using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Extensions
{
    public class SelectModel<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
        public string Label{ get; set; }
    }
}
