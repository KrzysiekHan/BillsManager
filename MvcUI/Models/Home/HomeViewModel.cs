using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUI.Models.Home
{
    public class HomeViewModel
    {
       public List<ChartDataSet> ChartDataSets { get; set; }
       public List<string> Months { get; set; }
    }
}