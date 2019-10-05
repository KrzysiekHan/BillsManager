using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModelLayer.Interfaces;

namespace MvcUI.Models
{
    public class RecipientVM
    {
        public int RecipientId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Account { get; set; }
        public string CustomerServiceUrl { get; set; }
        public bool Active { get; set; }

        public RecipientVM()
        {

        }

        public RecipientVM(IRecipient recipient)
        {
            this.Account = recipient.Account;
            this.RecipientId = recipient.RecipientId;
            this.CompanyName = recipient.CompanyName;
            this.Address = recipient.Address;
            this.CustomerServiceUrl = recipient.CustomerServiceUrl;
            this.Active = recipient.Active;
        }
    }
}