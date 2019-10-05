using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUI.Models.Bill
{
    public class IndexBillVM : CreateBillVM
    {

        public IndexBillVM()
        {

        }
        public int DaysBeforeDueDate { get; set; }
    }
}