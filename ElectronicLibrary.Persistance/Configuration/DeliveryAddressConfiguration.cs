using ElectronicLibrary.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Configuration
{
    public class DeliveryAddressConfiguration : BaseEntityConfiguration<Guid,DeliveryAddress>
    {
        public DeliveryAddressConfiguration() :base("DeliveryAddress")
        {

        }
    }
}
