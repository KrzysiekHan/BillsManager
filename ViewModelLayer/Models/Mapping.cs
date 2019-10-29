using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbAccess.Entities;
using ViewModelLayer.Interfaces;

namespace ViewModelLayer.Models
{
    public class Mapping : IMapping
    {
        private readonly IFactory _factory;
        public Mapping(IFactory factory)
        {
            _factory = factory;
        }

        public IBill DbBillToIBill(DbAccess.Entities.Bill entity)
        {
            IBill bill = _factory.BillFactory.NewBill(entity.BillId, entity.RecipientId, entity.BillTypeDictId, entity.Description, entity.DueAmount, entity.DueDate, entity.Periodical, entity.Period, entity.Paid);
            bill.Recipient = _factory.RecipientFactory.NewRecipient(entity.Recipient.RecipientId, entity.Recipient.CompanyName, entity.Recipient.Address, entity.Recipient.Account, entity.Recipient.CustomerServiceUrl, entity.Recipient.Active);
            bill.BillType = _factory.BillFactory.NewBillType(entity.BillTypeDict.BillTypeDictId, entity.BillTypeDict.Name);
            return bill;
        }

        public IBillType DbBillTypeToIBillType(BillTypeDict entity)
        {
            IBillType billType = _factory.BillFactory.NewBillType(entity.BillTypeDictId, entity.Name);
            return billType;
        }

        public ILog DbLogToILog(DbAccess.Entities.Log entity)
        {
            ILog log = _factory.LogFactory.NewLog(entity.Id, entity.Date, entity.Thread, entity.Level, entity.Logger, entity.Message, entity.Exception);
            return log;
        }

        public IRecipient DbRecipientToIRecipient(DbAccess.Entities.Recipient entity)
        {
            IRecipient recipient = _factory.RecipientFactory.NewRecipient(entity.RecipientId, entity.CompanyName, entity.Address, entity.Account, entity.CustomerServiceUrl, entity.Active);
            return recipient;
        }
    }
}
