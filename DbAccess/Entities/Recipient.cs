using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.Entities
{
    public class Recipient
    {
        public int RecipientId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Account { get; set; }
        public string CustomerServiceUrl { get; set; }
        public bool Active { get; set; }
    }
}
