using DbAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace UnitTesting
{
    public class TestDbContext : DbContext
    {
        public TestDbContext() : base("Name=TestDbContext")
        {
        }
        public TestDbContext(bool enableLazyLoading,bool enableProxyCreation): base("Name=TestDbContext")
        {
            Configuration.LazyLoadingEnabled = enableLazyLoading;
            Configuration.ProxyCreationEnabled = enableProxyCreation;
        }
        public TestDbContext(DbConnection connection): base(connection,true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillTypeDict> BillTypeDicts { get; set; }
        public DbSet<Recipient> Recipients { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TestDbContext>(new AlwaysCreateInitializer());
            base.OnModelCreating(modelBuilder);


        }

        public void Seed(TestDbContext Context)
        {
            var listBills = new List<Bill>()
            {
                new Bill(){ BillId = 1, BillTypeDictId = 1, RecipientId = 1, Description = "Opis 1", DueAmount = 20M, DueDate = DateTime.Now.AddMonths(0), Paid = false, Period = 1, Periodical = true },
                new Bill(){ BillId = 2, BillTypeDictId = 2, RecipientId = 2, Description = "Opis 2", DueAmount = 1M, DueDate = DateTime.Now.AddMonths(-1), Paid = false, Period = 1, Periodical = true, },
                new Bill(){ BillId = 3, BillTypeDictId = 3, RecipientId = 2, Description = "Opis 3", DueAmount = 5M, DueDate = DateTime.Now.AddMonths(2), Paid = true, Period = 0, Periodical = false, }
            };
            Context.Bills.AddRange(listBills);

            var listRecipients = new List<Recipient>()
            {
                new Recipient(){ RecipientId = 1, Account = "48 0000 6565 6565 5656 5656", Active = true, Address = "Bielsko-Biała Langiewicza 1", CompanyName = "Tauron", CustomerServiceUrl = "www.tauron.pl"},
                new Recipient(){ RecipientId = 2, Account = "48 1111 5454 5454 5454 4545", Active = true, Address = "Bielsko-Biała Michałowicza 24A", CompanyName = "PGE", CustomerServiceUrl = "www.pge.pl"},
                new Recipient(){ RecipientId = 3, Account = "48 2222 0430 3232 2323 2323", Active = true, Address = "Kęty Krakowska 34", CompanyName = "Miejski zakład wodociągów", CustomerServiceUrl = "www.mzwik.pl"},
            };
            Context.Recipients.AddRange(listRecipients);

            IList<BillTypeDict> billTypeDicts = new List<BillTypeDict>();
            billTypeDicts.Add(new BillTypeDict() { BillTypeDictId = 1, Name = "Prąd" });
            billTypeDicts.Add(new BillTypeDict() { BillTypeDictId = 2, Name = "Woda" });
            billTypeDicts.Add(new BillTypeDict() { BillTypeDictId = 3, Name = "Gaz" });
            Context.BillTypeDicts.AddRange(billTypeDicts);

            Context.SaveChanges();

            var bilist = Context.Bills.Include(x => x.Recipient).Include(x=>x.BillTypeDict).ToList();
        }


        public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<TestDbContext>
        {
            protected override void Seed(TestDbContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class CreateInitializer : CreateDatabaseIfNotExists<TestDbContext>
        {
            protected override void Seed(TestDbContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class AlwaysCreateInitializer : DropCreateDatabaseAlways<TestDbContext>
        {
            protected override void Seed(TestDbContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }
    }
}
