using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLayer.Interfaces.Bill
{
    public interface IBillFactory
    {
        IBill NewBill();
        IBillType NewBillType();
    }
}
