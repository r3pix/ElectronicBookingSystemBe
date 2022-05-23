using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Entities
{
    public class BookPiece : BaseEntity<Guid>
    {
        public string ReleaseYear { get; set; }
        public bool IsAvailable { get; set; }
        public Guid BookId { get; set; }

        public virtual Book Book { get; set; }  

        public virtual IEnumerable<BookPieceBorrow> Borrows { get; set; }
    }
}
