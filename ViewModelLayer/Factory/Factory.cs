using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Interfaces.Bill;
using ViewModelLayer.Interfaces.Recipient;

namespace ViewModelLayer.Factory
{
    public class Factory : IFactory
    {
        public Factory(IBillFactory billFactory, 
            IRecipientFactory recipientFactory,
            ILogFactory logFactory)
        {
            BillFactory = billFactory;
            RecipientFactory = recipientFactory;
            LogFactory = logFactory;
        }
        public IBillFactory BillFactory { get; }
        public IRecipientFactory RecipientFactory { get; }
        public ILogFactory LogFactory { get; }
    }
}
