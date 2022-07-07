using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Entities
{
    /// <summary>
    /// Address entity class
    /// </summary>
    public class Address : BaseEntity<Guid>
    {
        /// <summary>
        /// City of the address
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Street of the address
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Number of the house
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Postal code of address
        /// </summary>
        public string PostalCode { get; set; }  

        /// <summary>
        /// Id of user that ownes the address
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// User that ownes the address
        /// </summary>
        public virtual User User { get; set; }
    }
}
