using MvcUI.Models.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModelLayer.Models;

namespace MvcUI.Models
{
    public class BillsListViewModel
    {
        List<CreateBillVM> Bills { get; set; }
        List<BillType> BillTypes { get; set; }
    }
}