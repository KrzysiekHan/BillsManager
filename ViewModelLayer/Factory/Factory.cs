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
        public Factory(IBillFactory billFactory, IRecipientFactory recipientFactory)
        {
            BillFactory = billFactory;
            RecipientFactory = recipientFactory;

        }
        public IBillFactory BillFactory { get; }
        public IRecipientFactory RecipientFactory { get; }
    }
}
