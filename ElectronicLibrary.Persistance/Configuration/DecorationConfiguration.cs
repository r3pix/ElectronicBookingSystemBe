using ElectronicBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Configuration
{
    public class DecorationConfiguration : BaseEntityConfiguration<Guid, Decoration>
    {
        public DecorationConfiguration() : base("Decoration")
        {
        }
    }
}
