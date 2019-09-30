using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLayer.Interfaces.Recipient
{
    public interface IRecepientService
    {
        IRecipient GetRecepient(int recipientId);
        void CreateRecepient(IRecipient recipient);
        void UpdateRecepient(IRecipient recipient);
        IEnumerable<IRecipient> GetActiveRecipients();
    }
}
