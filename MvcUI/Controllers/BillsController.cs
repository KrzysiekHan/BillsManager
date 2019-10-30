using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using log4net;
using MvcUI.Common;
using MvcUI.Models;
using MvcUI.Models.Bill;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Interfaces.Bill;
using ViewModelLayer.Interfaces.Recipient;
using ViewModelLayer.Models;

namespace MvcUI.Controllers
{
    public class BillsController : Controller
    {
        private static readonly log4net.ILog log = LogManager.GetLogger(typeof(BillsController));

        private readonly IBillService _billService;
        private readonly IBillFactory _billFactory;
        private readonly IRecipientService _recipientService;
        public BillsController(IBillService billService, IBillFactory billFactory, IRecipientService recipientService)
        {
            _billService = billService;
            _billFactory = billFactory;
            _recipientService = recipientService;
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
            ViewBag.msg = TempData["ResultMessage"];
            
            return View(list);
        }

        // GET: Bills/Details/5
        public ActionResult Details(int? id)
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
            return View(new CreateBillVM(bill));
        }

        // GET: Bills/Create
        public ActionResult Create()
        {
            CreateBillVM vm = new CreateBillVM();
            List<BillTypeVM> types = CreateTypesList();
            vm.TypeItems = new SelectList(types, "BillTypeId", "Name");
            List<Recipient> recipients = CreateRecipientsList();
            vm.RecipientsList = new SelectList(recipients, "RecipientId", "CompanyName");
            vm.DueDate = DateTime.Now;
            return View(vm);
        }

        // POST: Bills/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillId,DueAmount,DueDate,Period,Description,BillTypeId,RecipientId")] CreateBillVM bill)
        {
            if (ModelState.IsValid)
            {
                IBill item =_billFactory.NewBill(bill.BillId, bill.RecipientId, bill.BillTypeId, bill.Description, bill.DueAmount, bill.DueDate, bill.Periodical, bill.Period, false);
                _billService.CreateBill(item);
                TempData["ResultMessage"] = "Utworzono rachunek";
                var recipient = _recipientService.GetRecepient(bill.RecipientId);
                log.Info("Utworzono rachunek " + "Id:" + bill.RecipientId + ", Odbiorca: "+ recipient.CompanyName + ", Kwota: " + bill.DueAmount);
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
            IBill bill = _billService.GetBill(CommonFunctions.NullableIntToInt(id));
            CreateBillVM vm = new CreateBillVM(bill);
            List<BillTypeVM> types = CreateTypesList();
            vm.TypeItems = new SelectList(types, "BillTypeId", "Name");
            List<Recipient> recipients = CreateRecipientsList();
            vm.RecipientsList = new SelectList(recipients, "RecipientId", "CompanyName");
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Bills/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( CreateBillVM bill)
        {
            if (ModelState.IsValid)
            {
                _billService.UpdateBill(
                    _billFactory.NewBill(bill.BillId,bill.RecipientId,bill.BillTypeId,bill.Description,bill.DueAmount,bill.DueDate,bill.Periodical,bill.Period,false)
                    );
                log.Info("Edytowano rachunek " +
                    "Id:" + bill.BillId );
                TempData["ResultMessage"] = "Zmiany zapisane";
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
            return View(new CreateBillVM(bill));
        }

        [HttpPost]
        public ActionResult PayBill(int id)
        {
            _billService.MarkBillAsPaid(id);
            log.Info("Opłacono rachunek " +
                    "Id:" + id);
            return Json(new { message = "Rachunek oznaczony jako opłacony" },JsonRequestBehavior.AllowGet); 
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _billService.RemoveBill(id);
            log.Info("Usunięto rachunek " +
        "Id:" + id);
            return RedirectToAction("Index");
        }

        public List<BillTypeVM> CreateTypesList()
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

        public List<Recipient> CreateRecipientsList()
        {
            IEnumerable<IRecipient> recipients = _recipientService.GetActiveRecipients();
            List<Recipient> returnList = new List<Recipient>();
            foreach (var item in recipients)
            {
                returnList.Add(new Recipient()
                {
                    RecipientId = item.RecipientId,
                    CompanyName = item.CompanyName
                });
            }
            return returnList;
        }

    }
}
