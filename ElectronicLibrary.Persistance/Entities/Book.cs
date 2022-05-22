using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Entities
{
    public class Book : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public float BorrowPrice { get; set; }

        public virtual IEnumerable<BookPiece> BookPieces { get; set; }  
    }
}
