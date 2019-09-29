using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLayer.Interfaces
{
    public interface IRecipient
    {
        int RecipientId { get; set; }
        string CompanyName { get; set; }
        string Address { get; set; }
        string Account { get; set; }
        string CustomerServiceUrl { get; set; }
        bool Active { get; set; }
    }
}
