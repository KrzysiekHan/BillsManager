using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Interfaces.Bill;

namespace MvcUI.Models.Home
{
    public class RecipientBillHistory
    {
        private readonly IBillService _billservice;
        public RecipientBillHistory(IRecipient recipient, IBillService service)
        {
            _billservice = service;
            this.RecipientId = recipient.RecipientId;
            this.RecipientName = recipient.CompanyName;
            _billservice.GetBillsForMonth();

        }

        public int RecipientId { get; set; }
        public string RecipientName { get; set; }
        public string BillType { get; set; }
        public List<BillHistory> BillForLastMonths { get; set; }
    }

    public class BillHistory
    {
        public int BillMonth { get; set; }
        public decimal DueAmount { get; set; }
        public bool BillPaid { get; set; }
    }
}