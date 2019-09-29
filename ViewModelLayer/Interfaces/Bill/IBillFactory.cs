using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLayer.Interfaces.Bill
{
    public interface IBillFactory
    {
        IBill NewBill(int billid, int recipientId, int billTypeId, string description, decimal dueAmount, DateTime dueDate, bool periodical);
        IBillType NewBillType(int billTypeId, string name);
    }
}
