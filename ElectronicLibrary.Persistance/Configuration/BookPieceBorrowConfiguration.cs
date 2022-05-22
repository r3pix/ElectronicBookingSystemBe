using ElectronicLibrary.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Configuration
{
    public class BookPieceBorrowConfiguration : BaseEntityConfiguration<Guid, BookPieceBorrow>
    {
        public BookPieceBorrowConfiguration() : base("BookPieceBorrow")
        {

        }
    }
}
