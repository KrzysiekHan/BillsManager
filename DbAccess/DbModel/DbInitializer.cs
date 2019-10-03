using DbAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.DbModel
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<BillManagerDbContext>
    {
        protected override void Seed(BillManagerDbContext context)
        {
            IList<BillTypeDict> billTypeDicts = new List<BillTypeDict>();
            billTypeDicts.Add(new BillTypeDict() { BillTypeDictId = 1, Name = "Prąd" });
            billTypeDicts.Add(new BillTypeDict() { BillTypeDictId = 2, Name = "Woda" });
            billTypeDicts.Add(new BillTypeDict() { BillTypeDictId = 3, Name = "Gaz" });
            billTypeDicts.Add(new BillTypeDict() { BillTypeDictId = 4, Name = "Internet" });
            billTypeDicts.Add(new BillTypeDict() { BillTypeDictId = 5, Name = "Telefon" });
            billTypeDicts.Add(new BillTypeDict() { BillTypeDictId = 6, Name = "Śmieci" });
            billTypeDicts.Add(new BillTypeDict() { BillTypeDictId = 7, Name = "Szambo" });
            billTypeDicts.Add(new BillTypeDict() { BillTypeDictId = 8, Name = "OC samochód" });
            billTypeDicts.Add(new BillTypeDict() { BillTypeDictId = 9, Name = "Przegląd samochód" });

            base.Seed(context);
        }
    }
}
