using DbAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Interfaces.Recipient;

namespace ViewModelLayer.Services
{
    public class RecipientService : IRecepientService
    {
        private readonly IRecipientRepository repo;
        private readonly IFactory factory;

        public RecipientService(IRecipientRepository repo, IFactory factory)
        {
            this.repo = repo;
            this.factory = factory;
        }

        public void CreateRecepient(IRecipient recipient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IRecipient> GetActiveRecipients()
        {
            throw new NotImplementedException();
        }

        public IRecipient GetRecepient(int recipientId)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecepient(IRecipient recipient)
        {
            throw new NotImplementedException();
        }
    }
}
