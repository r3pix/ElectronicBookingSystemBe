using ElectronicLibrary.Persistance.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Configuration
{
    public class BookConfiguration : BaseEntityConfiguration<Guid, Book>
    {
        public BookConfiguration() : base("Book")
        {

        }

        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasMany(x=>x.BookPieces).WithOne(x=>x.Book).HasForeignKey(x=>x.BookId);
            base.Configure(builder);
        }
    }
}
