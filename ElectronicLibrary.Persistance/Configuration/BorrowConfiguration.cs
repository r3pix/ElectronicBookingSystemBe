using ElectronicLibrary.Persistance.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Configuration
{
    public class BorrowConfiguration : BaseEntityConfiguration<Guid,Borrow>
    {
        public BorrowConfiguration() :base("Borrow")
        {

        }

        public override void Configure(EntityTypeBuilder<Borrow> builder)
        {
            builder.HasMany(x=>x.Books).WithOne(x => x.Borrow).HasForeignKey(x => x.BorrowId);
            builder.HasOne(x => x.DeliveryAddress).WithOne(x => x.Borrow).HasForeignKey<DeliveryAddress>(x => x.BorrowId);
            base.Configure(builder);
        }
    }
}
