using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Interfaces.Recipient;
using ViewModelLayer.Models;

namespace ViewModelLayer.Factory
{
    public class RecipientFactory : IRecipientFactory
    {
        public IRecipient NewRecipient(int RecipientId, string CompanyName, string Address, string Account, string CustomerServiceUrl, bool Active)
        {
            return new Recipient()
            {
                RecipientId = RecipientId,
                Account = Account,
                Active = Active,
                Address = Address,
                CompanyName = CompanyName,
                CustomerServiceUrl = CustomerServiceUrl
            };
        }
    }
}
