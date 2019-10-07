using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModelLayer.Interfaces
{
    public interface IMapping
    {
        IBill DbBillToIBill(DbAccess.Entities.Bill entity);
        IBillType DbBillTypeToIBillType(DbAccess.Entities.BillTypeDict entity);
        IRecipient DbRecipientToIRecipient(DbAccess.Entities.Recipient entity);
    }
}
