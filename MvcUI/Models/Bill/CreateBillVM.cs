using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcUI.Models.Bill
{
    public class CreateBillVM
    {

        public int BillId { get; set; }

        [Display(Name = "Wysokość opłaty")]
        [DataType(DataType.Currency)]
        public decimal DueAmount { get; set; }

        [Display(Name = "Termin")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public bool Periodical { get; set; }

        [Display(Name = "Komentarz")]
        public string Description { get; set; }

        [Display(Name = "Odbiorca płatności")]
        public int RecipientId { get; set; }

        [Display(Name = "Kategoria płatności")]
        public int BillTypeId { get; set; }

        [Display(Name = "Okres płatności w miesiącach (0 - jednorazowa)")]
        public int Period { get; set; }

        List<BillTypeVM> billTypes { get; set; }

        List<Recipient> recipients { get; set; }

        public IEnumerable<SelectListItem> TypeItems { get; set; }

        public IEnumerable<SelectListItem> RecipientsList { get; set; }
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