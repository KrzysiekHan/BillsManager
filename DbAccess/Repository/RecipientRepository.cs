using DbAccess.Entities;
using DbAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.Repository
{
    public class RecipientRepository : GenericRepository<Recipient>, IRecipientRepository
    {
    }
}
