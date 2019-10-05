using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MvcUI.Common;
using MvcUI.Models;
using MvcUI.Models.Bill;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Interfaces.Bill;
using ViewModelLayer.Models;

namespace MvcUI.Controllers
{
    public class BillsController : Controller
    {
        private readonly IBillService _billService;
        private readonly IBillFactory _billFactory;
        public BillsController(IBillService billService, IBillFactory billFactory)
        {
            _billService = billService;
            _billFactory = billFactory;
        }

        // GET: Bills
        public ActionResult Index()
        {
            var BillsList = _billService.GetAllBills();
            List<CreateBillVM> list = new List<CreateBillVM>();
            foreach (var item in BillsList)
            {
                list.Add(new CreateBillVM(item));
            }
            return View(list);
        }

        // GET: Bills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int idn = id ?? default(int);
            IBill bill = _billService.GetBill(idn);

            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // GET: Bills/Create
        public ActionResult Create()
        {
            CreateBillVM vm = new CreateBillVM();
            List<BillTypeVM> types = CreateTypesList();
            vm.TypeItems = new SelectList(types, "BillTypeId", "Name");
            return View(vm);
        }

        // POST: Bills/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillId,DueAmount,DueDate,Periodical,Description,BillTypeId")] CreateBillVM bill)
        {
            if (ModelState.IsValid)
            {
                IBill item =_billFactory.NewBill(bill.BillId, bill.RecipientId, bill.BillTypeId, bill.Description, bill.DueAmount, bill.DueDate, bill.Periodical);
                _billService.CreateBill(item);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
                return RedirectToAction("Index");
            }

            return View(bill);
        }

        // GET: Bills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int idn = id ?? default(int);
            IBill bill = _billService.GetBill(idn);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Bills/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillId,DueAmount,DueDate,Periodical,Description")] IBill bill)
        {
            if (ModelState.IsValid)
            {
                _billService.UpdateBill(bill);
                return RedirectToAction("Index");
            }
            return View(bill);
        }

        // GET: Bills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IBill bill = _billService.GetBill(CommonFunctions.NullableIntToInt(id));
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _billService.RemoveBill(id);
            return RedirectToAction("Index");
        }

        private List<BillTypeVM> CreateTypesList()
        {
            IEnumerable<IBillType> billTypes = _billService.GetBillTypes();
            List<BillTypeVM> returnList = new List<BillTypeVM>();
            foreach (var item in billTypes)
            {
                returnList.Add(new BillTypeVM()
                {
                    BillTypeId = item.BillTypeId,
                    Name = item.Name
                });
            }
            return returnList;
        }

    }
}
