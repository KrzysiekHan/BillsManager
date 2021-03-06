﻿using DbAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.DbModel
{
    public class BillManagerDbContext : DbContext
    {

        public BillManagerDbContext():base("BillsReminder")
        {
            Database.SetInitializer<BillManagerDbContext>(new DbInitializer());
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillTypeDict> BillTypeDicts { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
