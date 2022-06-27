using ElectronicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Configuration
{
    public class FileConfiguration : BaseEntityConfiguration<Guid, File>
    {
        public FileConfiguration() : base("File")
        {
        }
    }
}
