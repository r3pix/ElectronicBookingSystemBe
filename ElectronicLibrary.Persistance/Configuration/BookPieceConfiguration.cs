using ElectronicLibrary.Persistance.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Configuration
{
    public class BookPieceConfiguration :BaseEntityConfiguration<Guid,BookPiece>
    {
        public BookPieceConfiguration() : base("BookPiece")
        {

        }

        public override void Configure(EntityTypeBuilder<BookPiece> builder)
        {
            builder.HasMany(x=>x.Borrows).WithOne(x=>x.BookPiece).HasForeignKey(x=>x.BookPieceId);
            base.Configure(builder);
        }
    }
}
