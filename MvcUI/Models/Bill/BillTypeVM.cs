using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModelLayer.Interfaces;

namespace MvcUI.Models.Bill
{
    public class BillTypeVM
    {
        public BillTypeVM()
        {

        }
        public BillTypeVM(IBillType billType)
        {
            this.BillTypeId = billType.BillTypeId;
            this.Name = billType.Name;
        }

        public int BillTypeId { get; set; }
        public string Name { get; set; }
    }
}