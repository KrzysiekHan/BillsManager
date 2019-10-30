using MvcUI.Models.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUI.Models.Home
{
    public class ChartDataSet
    {
        public string Label { get; set; }
        public List<CreateBillVM> Data { get; set; }
    }


}