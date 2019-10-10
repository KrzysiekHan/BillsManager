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
    public class RecipientService : IRecipientService
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
            DbAccess.Entities.Recipient dbrecipient = new DbAccess.Entities.Recipient()
            {
                RecipientId = recipient.RecipientId,
                CompanyName = recipient.CompanyName,
                Account = recipient.Account,
                Active = true,
                Address = recipient.Address,
                CustomerServiceUrl = recipient.CustomerServiceUrl
            };
            repo.Insert(dbrecipient);
            repo.Save();
        }

        public void UpdateRecepient(IRecipient recipient)
        {
            DbAccess.Entities.Recipient dbrecipient = this.repo.GetById(recipient.RecipientId);
            dbrecipient.Account = recipient.Account;
            dbrecipient.Address = recipient.Address;
            dbrecipient.CompanyName = recipient.CompanyName;
            dbrecipient.CustomerServiceUrl = recipient.CustomerServiceUrl;
            dbrecipient.Active = true;
            this.repo.Update(dbrecipient);
            this.repo.Save();

        }

        public IEnumerable<IRecipient> GetActiveRecipients()
        {
            var list = this.repo.GetWithPredicate(x => x.Active == true).ToList();
            foreach (var item in list)
            {
                yield return factory.RecipientFactory.NewRecipient(item.RecipientId, item.CompanyName, item.Address, item.Account, item.CustomerServiceUrl, item.Active);

            }
        }

        public IRecipient GetRecepient(int recipientId)
        {
            var recipient = this.repo.GetById(recipientId);
            return factory.RecipientFactory.NewRecipient(recipient.RecipientId, recipient.CompanyName, recipient.Address, recipient.Account, recipient.CustomerServiceUrl, recipient.Active);
        }

        public void DeactivateRecipient(int recipientId)
        {
            object id = recipientId;
            var recipient = this.repo.GetById(id);
            recipient.Active = false;
            this.repo.Update(recipient);
            this.repo.Save();
        }
    }
}
