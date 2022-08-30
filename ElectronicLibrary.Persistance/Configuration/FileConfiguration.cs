using ElectronicBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Configuration
{
    public class FileConfiguration : BaseEntityConfiguration<Guid, File>
    {
        public FileConfiguration() : base("File")
        {
        }

        public override void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasOne(x => x.Room).WithMany(x => x.Files).HasForeignKey(x => x.RoomId);
            builder.HasOne(x => x.Decoration).WithMany(x => x.Files).HasForeignKey(x=>x.DecorationId);
            builder.HasOne(x => x.Equipment).WithMany(x => x.Files).HasForeignKey(x=>x.EquipmentId);

            base.Configure(builder);
        }
    }
}
