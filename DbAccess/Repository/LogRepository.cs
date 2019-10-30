using DbAccess.DbModel;
using DbAccess.Entities;
using DbAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.Repository
{
    class LogRepository : GenericRepository<Log>, ILogRepository
    {
        private readonly BillManagerDbContext _context = new BillManagerDbContext();

        public void DeleteAllLogs()
        {
            this._context.Database.ExecuteSqlCommand("delete from dbo.Logs");
        }
    }
}
