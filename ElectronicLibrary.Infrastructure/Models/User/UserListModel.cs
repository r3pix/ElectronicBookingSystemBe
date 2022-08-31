using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Models.User
{
    public class UserListModel
    {
        //user Data
        public Guid Id { get; set; }
        public string Email { get; set; }

        //identity Data
        public Guid IdentityId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        //address Data
        public Guid AddressId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }

        //role
        public string Role { get; set; }

    }
}
