using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLayer.Interfaces.Recipient
{
    public interface IRecipientFactory
    {
        IRecipient NewRecipient();
    }
}
