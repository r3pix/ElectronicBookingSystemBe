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
    public class CategoryConfiguration : BaseEntityConfiguration<Guid, Category>
    {
        public CategoryConfiguration() : base("Category")
        {
        }

        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.Rooms).WithOne(x => x.Category).HasForeignKey(x=>x.CategoryId);

            base.Configure(builder);
        }
    }
}
