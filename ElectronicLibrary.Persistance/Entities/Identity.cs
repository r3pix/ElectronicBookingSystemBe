using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Entities
{
    public class Identity : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
