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
        public int Period { get; set; }
        public bool Paid { get; set; }

        public int RecipientId { get; set; }
        public virtual Recipient Recipient { get; set; }

        public int BillTypeDictId { get; set; }
        public virtual BillTypeDict BillTypeDict { get; set; }
    }
}
