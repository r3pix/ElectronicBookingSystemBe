using ElectronicLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Configuration
{
    public class ServiceConfiguration : BaseEntityConfiguration<Guid, Service>
    {
        public ServiceConfiguration() : base("Service")
        {
        }
    }
}
