using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLayer.Interfaces
{
    public interface IBill
    {
        int BillId { get; set; }
        int RecipientId { get; set; }
        int BillTypeId { get; set; }
        decimal DueAmount { get; set; }
        DateTime DueDate { get; set; }
        bool Periodical { get; set; }
        string Description { get; set; }
        IRecipient Recipient { get; set; }
        IBillType BillType { get; set; }
    }
}
