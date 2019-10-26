using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Models;

namespace UnitTesting.Mocks
{
    public class MockingFactory
    {
        internal IBill CreateBill()
        {
            IBill bill = new Bill { BillId = 1, Description = "opis 1", DueAmount = 10.0M, DueDate = DateTime.Now, Paid = false, Period = 3, Periodical = true };
            return bill;
        }

        internal IEnumerable<IBill> CreateBillList()
        {
            IEnumerable<IBill> list = new List<Bill>()
            {
                new Bill{ BillId = 1, Description = "opis 1", DueAmount = 10.0M, DueDate = DateTime.Now, Paid = false, Period = 3, Periodical = true },
                new Bill{ BillId = 2, Description = "opis 2", DueAmount = 3.0M, DueDate = DateTime.Now.AddMonths(-1), Paid = false, Period = 1, Periodical = true },
                new Bill{ BillId = 3, Description = "opis 3", DueAmount = 34.0M, DueDate = DateTime.Now.AddMonths(1), Paid = true, Period = 0, Periodical = true }
            };
            return list;
        }

        internal IEnumerable<IBillType> CreateBillTypesList()
        {
            IEnumerable<IBillType> list = new List<BillType>()
            {
                new BillType() { BillTypeId = 1, Name = "Prąd"},
                new BillType() { BillTypeId = 2, Name = "Woda"}
            };
            return list;
        }

        internal IEnumerable<IRecipient> CreateRecipients()
        {
            IEnumerable<IRecipient> list = new List<Recipient>()
            {
                new Recipient(){ RecipientId = 1, Account = "48 0000 6565 6565 5656 5656", Active = true, Address = "Bielsko-Biała Langiewicza 1", CompanyName = "Tauron", CustomerServiceUrl = "www.tauron.pl"},
                new Recipient(){ RecipientId = 2, Account = "48 1111 5454 5454 5454 4545", Active = true, Address = "Bielsko-Biała Michałowicza 24A", CompanyName = "PGE", CustomerServiceUrl = "www.pge.pl"},
                new Recipient(){ RecipientId = 3, Account = "48 2222 0430 3232 2323 2323", Active = true, Address = "Kęty Krakowska 34", CompanyName = "Miejski zakład wodociągów", CustomerServiceUrl = "www.mzwik.pl"},
            };
            return list;
        }
    }
}
