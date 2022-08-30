using ElectronicBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Configuration
{
    public class UserConfiguration : BaseEntityConfiguration<Guid,User>
    {
        public UserConfiguration() :base("User")
        {

        }

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId);
            builder.HasOne(x => x.Identity).WithOne(x => x.User).HasForeignKey<Identity>(x => x.UserId);
            builder.HasOne(x => x.Address).WithOne(x => x.User).HasForeignKey<Address>(x => x.UserId);
            builder.HasMany(x=>x.Bookings).WithOne(x=>x.User).HasForeignKey(x => x.UserId);
            base.Configure(builder);
        }
    }
}
