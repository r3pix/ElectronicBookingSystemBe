using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Models.Booking
{
    public class BookingInvoiceModel
    {
        //booking Data
        /// <summary>
        /// Gets or sets Id of the Booking
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets name of the booking
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets totalTables
        /// </summary>
        public int TotalTables { get; set; }

        /// <summary>
        /// Gets or sets TotalPlaces
        /// </summary>
        public int TotalPlaces { get; set; }

        /// <summary>
        /// Gets or sets TotalCost
        /// </summary>
        public int TotalCost { get; set; }

        /// <summary>
        /// Gets or sets Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }

        //UserData
        /// <summary>
        /// Gets or sets User email
        /// </summary>
        public string Email { get; set; }

        //identityData
        /// <summary>
        /// Gets or sets user FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets user LastName
        /// </summary>
        public string LastName { get; set; }

        //decorationData\
        /// <summary>
        /// Gets or sets Decoration Name
        /// </summary>
        public string DecorationName { get; set; }

        /// <summary>
        /// Gets or sets Decoraiton cost
        /// </summary>
        public string DecorationCost { get; set; }

        //equipmentData
        /// <summary>
        /// Gets or sets EquipmentName
        /// </summary>
        public string EquipmentName { get; set; }

        /// <summary>
        /// gets or sets equipment cost
        /// </summary>
        public string EquipmentCost { get; set; }

        //RoomData
        /// <summary>
        /// Gets or sets Room name
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// gets or sets Room Cost
        /// </summary>
        public string RoomCost { get; set; }

        //ServiceData
        /// <summary>
        /// Gets or sets Service Name
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// gets or sets Service Cost
        /// </summary>
        public string ServiceCost { get; set; }
    }
}
