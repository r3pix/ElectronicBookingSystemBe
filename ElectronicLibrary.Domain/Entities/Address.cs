using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Entities
{
    public class Address : BaseEntity<Guid>
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }  
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
