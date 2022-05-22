using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Persistance.Entities
{
    public class Borrow : BaseEntity<Guid>
    {
        public DateTime DateTo { get; set; }
        public float Penalty { get; set; }
        public float SumBorrowPrice { get; set; }
        public Guid UserId {get; set;}

        public virtual User User { get; set; }
        public virtual DeliveryAddress DeliveryAddress { get; set; }
        public virtual IEnumerable<BookPieceBorrow> Books { get; set; }
    }
}
