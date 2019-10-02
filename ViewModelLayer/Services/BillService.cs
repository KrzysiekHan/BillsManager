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
            DbAccess.Entities.Bill dbbill = new DbAccess.Entities.Bill()
            {
                BillId = bill.BillId,
                Description = bill.Description,
                DueAmount = bill.DueAmount,
                DueDate = bill.DueDate,
                Periodical = bill.Periodical,
                BillTypeDictId = bill.BillTypeId,
                RecipientId = bill.RecipientId
            };
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
        }

        public IEnumerable<IBill> GetAllBills()
        {
            var response = this.repo.GetAll().ToList();
            foreach (var item in response)
            {
                yield return factory.BillFactory.NewBill(item.BillId, item.RecipientId, item.BillTypeDictId, item.Description, item.DueAmount, item.DueDate, item.Periodical);
            }
        }

        public IBill GetBill(int billId)
        {
            var bill = this.repo.GetById(billId);
            return factory.BillFactory.NewBill(bill.BillId,bill.RecipientId, bill.BillTypeDictId, bill.Description, bill.DueAmount, bill.DueDate, bill.Periodical);
        }

        public IEnumerable<IBill> GetBillsForMonth(int month)
        {
            var response = this.repo.GetWithPredicate(x => x.DueDate.Month == month).ToList();
            foreach (var item in response)
            {
                yield return factory.BillFactory.NewBill(item.BillId, item.RecipientId, item.BillTypeDictId, item.Description, item.DueAmount, item.DueDate, item.Periodical);
            }
        }

        public IEnumerable<IBillType> GetBillTypes()
        {
            var response = this.typerepo.GetAll().ToList();
            foreach (var item in response)
            {
                yield return factory.BillFactory.NewBillType(item.BillTypeDictId, item.Name);
            }
        }

        public void RemoveBill(int id)
        {
            repo.Delete(id);
            repo.Save();
        }
    }
}
