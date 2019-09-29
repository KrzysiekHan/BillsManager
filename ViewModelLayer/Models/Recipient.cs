using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Interfaces;

namespace ViewModelLayer.Models
{
    public class Recipient : IRecipient
    {
        public int RecipientId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Account { get; set; }
        public string CustomerServiceUrl { get; set; }
        public bool Active { get; set; }
    }
}
