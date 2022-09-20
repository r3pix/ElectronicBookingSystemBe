using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Infrastructure.Models.Booking
{
    public class BookingListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalPlaces { get; set; }
        public int TotalTables { get; set; }
        public float TotalCost { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid DecorationId { get; set; }
        public string DecorationName { get; set; }
        public Guid EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserRole { get; set; }
    }
}
