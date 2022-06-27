using ElectronicLibrary.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Entities
{
    public class File : BaseEntity<Guid>
    {
        public string FileName { get; set; }
        public string UploadPath { get; set; }
        public string PathFileName { get; set; }
    }
}
