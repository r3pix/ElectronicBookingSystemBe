using ElectronicLibrary.Domain.Entities;
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
            builder.HasOne(x => x.Room).WithOne(x => x.File).HasForeignKey<File>(x => x.RoomId);
            builder.HasOne(x => x.Decoration).WithOne(x => x.File).HasForeignKey<File>(x=>x.DecorationId);
            builder.HasOne(x => x.Equipment).WithOne(x => x.File).HasForeignKey<File>(x=>x.EquipmentId);

            base.Configure(builder);
        }
    }
}
