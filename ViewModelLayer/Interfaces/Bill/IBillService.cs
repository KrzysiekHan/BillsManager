using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLayer.Interfaces.Bill
{
    public interface IBillService
    {
        IBill GetBill(int billId);
        void CreateBill(IBill bill);
        void UpdateBill(IBill bill);
        void MarkBillAsPaid(int billId);
        void RemoveBill(int id);
        IEnumerable<IBillType> GetBillTypes();
        IEnumerable<IBill> GetAllBills();
        IEnumerable<IBill> GetBillsForMonth(int month);
    }
}
