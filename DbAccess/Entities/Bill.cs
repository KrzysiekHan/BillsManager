using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.Entities
{
   public class Bill
    {
        public int BillId { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime DueDate { get; set; }
        public bool Periodical { get; set; }
        public string Description { get; set; }

        public Recipient Recipient { get; set; }
        public BillTypeDict BillTypeDict { get; set; }
    }
}
