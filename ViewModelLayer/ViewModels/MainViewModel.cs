using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Models;

namespace ViewModelLayer.ViewModels
{
    public class MainViewModel
    {
        List<Bill> Bills { get; set; }
        List<Recipient> Recipients { get; set; }
        List<BillType> Types { get; set; }
    }
}
