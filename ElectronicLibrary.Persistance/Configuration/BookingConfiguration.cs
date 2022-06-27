using ElectronicLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Configuration
{
    public class BookingConfiguration : BaseEntityConfiguration<Guid, Booking>
    {
        public BookingConfiguration() : base("Booking")
        {
        }

        public override void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasOne(x => x.Decoration).WithMany(x => x.Bookings).HasForeignKey(x => x.DecorationId);
            builder.HasOne(x => x.Equipment).WithMany(x => x.Bookings).HasForeignKey(x => x.EquipmentId);
            builder.HasOne(x => x.Room).WithMany(x => x.Bookings).HasForeignKey(x => x.RoomId);
            builder.HasOne(x => x.User).WithMany(x => x.Bookings).HasForeignKey(x => x.UserId);

            base.Configure(builder);
        }
    }
}
