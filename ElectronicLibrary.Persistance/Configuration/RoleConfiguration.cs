using ElectronicLibrary.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Configuration
{
    public class RoleConfiguration : BaseEntityConfiguration<Guid,Role>
    {
        public RoleConfiguration() : base("Role")
        {

        }
    }
}
