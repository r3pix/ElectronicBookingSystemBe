using ElectronicLibrary.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Configuration
{
    public class IdentityConfiguration :BaseEntityConfiguration<Guid,Identity>
    {
        public IdentityConfiguration() : base("Identity")
        {

        }
    }
}
