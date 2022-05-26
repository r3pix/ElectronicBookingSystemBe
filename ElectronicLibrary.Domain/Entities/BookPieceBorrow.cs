using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Entities
{
    public class BookPieceBorrow : BaseEntity<Guid>
    {
        public Guid BookPieceId { get; set; }

        public Guid BorrowId { get; set; }

        public virtual BookPiece BookPiece { get; set; }
        public virtual Borrow Borrow { get; set; }

    }
}
