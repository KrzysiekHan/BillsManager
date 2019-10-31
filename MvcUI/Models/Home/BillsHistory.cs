using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Interfaces.Bill;

namespace MvcUI.Models.Home
{
    public class BillsHistory
    {
        private readonly IBillService _billservice;

        public BillsHistory(IBillService service)
        {
            this.BillForLastMonths = new List<BillHistory>();
            _billservice = service;        
            for (int i = 0; i < 5; i++) //get all bills for last 6 months
            {          
                var bills = _billservice.GetBillsForMonth(DateTime.Now.Month - i);
                if (bills != null)
                {
                    foreach (var item in bills)
                    {
                        BillHistory bh = new BillHistory();
                        bh = MapIBillToBillHistory(item);
                        this.BillForLastMonths.Add(bh);
                    }
                }
            }
        }

        public int RecipientId { get; set; }
        public string RecipientName { get; set; }
        public string BillType { get; set; }
        public List<BillHistory> BillForLastMonths { get; set; }

        private BillHistory MapIBillToBillHistory(IBill bill)
        {
            BillHistory bh = new BillHistory();
            bh.DueAmount = bill.DueAmount;
            bh.BillMonth = bill.DueDate.Month;
            bh.BillPaid = bill.Paid;
            bh.RecipientId = bill.RecipientId;
            return bh;
        }
    }

    public class BillHistory
    {
        public int RecipientId { get; set; }
        public int BillMonth { get; set; }
        public decimal DueAmount { get; set; }
        public bool BillPaid { get; set; }

    }


}