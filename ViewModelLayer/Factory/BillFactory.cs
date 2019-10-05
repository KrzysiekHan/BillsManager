using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Interfaces.Bill;
using ViewModelLayer.Models;

namespace ViewModelLayer.Factory
{
    public class BillFactory : IBillFactory
    {

        public IBill NewBill(int billid, int recipientId, int billTypeId, string description, decimal dueAmount, DateTime dueDate, bool periodical, int period, bool paid)
        {
            return new Bill()
            {
                BillId = billid,
                RecipientId = recipientId,
                BillTypeId = billTypeId,
                Description = description,
                DueAmount = dueAmount,
                DueDate = dueDate,
                Periodical = periodical,
                Period = period,
                Paid = paid
            };
        }

        public IBillType NewBillType(int billTypeId, string name)
        {
            return new BillType()
            {
                BillTypeId = billTypeId,
                Name = name
            };
        }
    }
}
