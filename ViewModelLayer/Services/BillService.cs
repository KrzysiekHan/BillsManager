using DbAccess.Entities;
using DbAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Interfaces.Bill;

namespace ViewModelLayer.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository repo;
        private readonly IBillTypeDictRepository typerepo;
        private readonly IFactory factory;
        public BillService(IBillRepository billRepository, IFactory factory, IBillTypeDictRepository typerepo)
        {
            this.repo = billRepository;
            this.factory = factory;
            this.typerepo = typerepo;
        }

        public void CreateBill(IBill bill)
        {
            DbAccess.Entities.Bill dbbill;
            if (bill.Period > 0)
            {
                dbbill = new DbAccess.Entities.Bill()
                {
                    BillId = bill.BillId,
                    Description = bill.Description,
                    DueAmount = bill.DueAmount,
                    DueDate = bill.DueDate,
                    Periodical = true,
                    BillTypeDictId = bill.BillTypeId,
                    RecipientId = bill.RecipientId,
                    Period = bill.Period,
                    Paid = false
                    
                };
            } else
            {
                dbbill = new DbAccess.Entities.Bill()
                {
                    BillId = bill.BillId,
                    Description = bill.Description,
                    DueAmount = bill.DueAmount,
                    DueDate = bill.DueDate,
                    Periodical = false,
                    BillTypeDictId = bill.BillTypeId,
                    RecipientId = bill.RecipientId,
                    Period = 0,
                    Paid = false
                };
            }


            repo.Insert(dbbill);
            repo.Save();
        }


        public void UpdateBill(IBill bill)
        {
            DbAccess.Entities.Bill dbbill = this.repo.GetById(bill.BillId);
            dbbill.Description = bill.Description;
            dbbill.DueAmount = bill.DueAmount;
            dbbill.DueDate = bill.DueDate;
            dbbill.Periodical = bill.Periodical;
            dbbill.BillTypeDictId = bill.BillTypeId;
            dbbill.RecipientId = bill.RecipientId;
            dbbill.Paid = bill.Paid;
        }

        public void MarkBillAsPaid(int billId)
        {
            DbAccess.Entities.Bill dbbill = this.repo.GetById(billId);
            dbbill.Paid = true;
     //TODO mark bill as paid not finished
        }

        public IEnumerable<IBill> GetAllBills()
        {
            var response = this.repo.GetAll().ToList();
            foreach (var item in response)
            {
                yield return factory.BillFactory.NewBill(item.BillId, item.RecipientId, item.BillTypeDictId, item.Description, item.DueAmount, item.DueDate, item.Periodical, item.Period, item.Paid);
            }
        }

        public IBill GetBill(int billId)
        {
            var bill = this.repo.GetById(billId);
            return factory.BillFactory.NewBill(bill.BillId,bill.RecipientId, bill.BillTypeDictId, bill.Description, bill.DueAmount, bill.DueDate, bill.Periodical, bill.Period, bill.Paid);
        }

        public IEnumerable<IBill> GetBillsForMonth(int month)
        {

            var list = this.repo.GetAll().ToList();
            foreach (var item in list)
            {
                //periodical created in past
                if (item.Periodical && (DateTime.Now > item.DueDate))
                {
                    int monthDifference = ((DateTime.Now.Year - item.DueDate.Year) * 12) + DateTime.Now.Month - item.DueDate.Month;
                    if (monthDifference%item.Period == 0) 
                    {
                        yield return factory.BillFactory.NewBill(item.BillId, item.RecipientId, item.BillTypeDictId, item.Description, item.DueAmount, item.DueDate, item.Periodical, item.Period, item.Paid);
                    }
                }

                //periodical not paid yet
                if (item.Periodical && DateTime.Now <= item.DueDate && item.DueDate.Month == month)
                {
                    yield return factory.BillFactory.NewBill(item.BillId, item.RecipientId, item.BillTypeDictId, item.Description, item.DueAmount, item.DueDate, item.Periodical, item.Period, item.Paid);
                }
                
                //not periodical for this month
                if (!item.Periodical && item.DueDate.Month == month)
                {
                    yield return factory.BillFactory.NewBill(item.BillId, item.RecipientId, item.BillTypeDictId, item.Description, item.DueAmount, item.DueDate, item.Periodical, item.Period, item.Paid);
                }
                
            }
        }

        public IEnumerable<IBillType> GetBillTypes()
        {
            List<BillTypeDict> list = this.typerepo.GetAll().ToList();
            foreach (var item in list)
            {
                var response = factory.BillFactory.NewBillType(item.BillTypeDictId, item.Name);
                yield return response;
            }
        }

        public void RemoveBill(int id)
        {
            repo.Delete(id);
            repo.Save();
        }


    }
}
