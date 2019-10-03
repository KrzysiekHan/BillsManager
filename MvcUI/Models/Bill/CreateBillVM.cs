using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Models;

namespace MvcUI.Models.Bill
{
    public class CreateBillVM
    {
        public int BillId { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime DueDate { get; set; }
        public bool Periodical { get; set; }
        public string Description { get; set; }
        public int RecipientId { get; set; }
        public int BillTypeId { get; set; }

        List<BillType> billTypes { get; set; }
        List<Recipient> recipients { get; set; }

        public CreateBillVM()
        {

        }

        public CreateBillVM(IBill bill)
        {
            this.BillId = bill.BillId;
            this.BillTypeId = bill.BillTypeId;
            this.RecipientId = bill.RecipientId;
            this.Description = bill.Description;
            this.DueAmount = bill.DueAmount;
            this.DueDate = bill.DueDate;
            this.Periodical = bill.Periodical;

        }
    }
}