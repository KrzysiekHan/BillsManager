using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Interfaces.Bill;
using ViewModelLayer.Interfaces.Recipient;

namespace ViewModelLayer.Interfaces
{
    public interface IFactory
    {
        IBillFactory BillFactory { get; }
        IRecipientFactory RecipientFactory { get; }
        ILogFactory LogFactory { get; }
    }
}
