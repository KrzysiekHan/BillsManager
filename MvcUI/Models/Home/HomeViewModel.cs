using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUI.Models.Home
{
    public class HomeViewModel
    {
       public BillsHistory BillsHalfYearHistory { get; set; }
       public List<string> Months { get; set; }
    }
}