using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.User.Commands
{
    /// <summary>
    /// Command class for user registrations
    /// </summary>
    public class RegisterUserCommand : IRequest
    {
        /// <summary>
        /// Email of the User
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password of the user
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// First name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        public string LastName { get; set; }

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
    }
}
