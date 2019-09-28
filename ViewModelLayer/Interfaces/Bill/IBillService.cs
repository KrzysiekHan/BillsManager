﻿using System;
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
        IEnumerable<IBillType> GetBillTypes();
        IEnumerable<IBill> GetAllBills();
        IEnumerable<IBill> GetBillsForMonth();
    }
}
