using DbAccess.Repository;
using DbAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Services;

namespace ViewModelLayer
{
    public class testingDal
    {
        private IBillRepository billRepository = new BillRepository();
        private IFactory factory = new Factory();
        BillService billService = new BillService(billRepository, );
        
    }
}
