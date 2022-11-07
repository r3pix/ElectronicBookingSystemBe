using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Persistance.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Persistance.Configuration
{
    public class OpinionConfiguration : BaseEntityConfiguration<Guid, Opinion>
    {
        public OpinionConfiguration() : base("Opinion")
        {
        }

        public override void Configure(EntityTypeBuilder<Opinion> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Room).WithMany(x => x.Opinions).HasForeignKey(x => x.RoomId);
            builder.HasOne(x => x.User).WithMany(x => x.Opinions).HasForeignKey(x => x.UserId);
        }
    }
}
