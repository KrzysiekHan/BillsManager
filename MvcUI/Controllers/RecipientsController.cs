using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcUI.Common;
using MvcUI.Models;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Interfaces.Recipient;
using ViewModelLayer.Models;

namespace MvcUI.Controllers
{
    public class RecipientsController : Controller
    {
        private readonly IRecipientService _recipientService;
        private readonly IRecipientFactory _recipientFactory;
        private readonly IMapping _mapping;

        public RecipientsController(IRecipientService recipientService, IRecipientFactory recipientFactory, IMapping mapping)
        {
            _recipientService = recipientService;
            _recipientFactory = recipientFactory;
            _mapping = mapping;
        }

        // GET: Recipients
        public ActionResult Index()
        {
            var RecipientsList = _recipientService.GetActiveRecipients();
            List<RecipientVM> vm = new List<RecipientVM>();
            foreach (var item in RecipientsList)
            {
                vm.Add(new RecipientVM(item));
            }
            ViewBag.msg = TempData["ResultMessage"];
            return View(vm);
        }

        // GET: Recipients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IRecipient recipient = _recipientService.GetRecepient(CommonFunctions.NullableIntToInt(id));
            RecipientVM vm = new RecipientVM(recipient);
            if (recipient == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // GET: Recipients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipients/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipientId,CompanyName,Address,Account,CustomerServiceUrl")] RecipientVM recipient)
        {
            if (ModelState.IsValid)
            {
                IRecipient item = _recipientFactory.NewRecipient(recipient.RecipientId, recipient.CompanyName, recipient.Address, recipient.Account, recipient.CustomerServiceUrl, recipient.Active);
                _recipientService.CreateRecepient(item);
                TempData["ResultMessage"] = "Utworzono odbiorcę";
                return RedirectToAction("Index");
            }

            return View(recipient);
        }

        // GET: Recipients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IRecipient recipient = _recipientService.GetRecepient(CommonFunctions.NullableIntToInt(id));
            RecipientVM vm = new RecipientVM(recipient);
            if (recipient == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Recipients/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipientId,CompanyName,Address,Account,CustomerServiceUrl,Active")] RecipientVM recipient)
        {
            if (ModelState.IsValid)
            {
                _recipientService.UpdateRecepient(
                    _recipientFactory.NewRecipient(recipient.RecipientId,recipient.CompanyName,recipient.Address,recipient.Account,recipient.CustomerServiceUrl,recipient.Active)
                    );
                return RedirectToAction("Index");
            }
            return View(recipient);
        }

        // GET: Recipients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IRecipient recipient = _recipientService.GetRecepient(CommonFunctions.NullableIntToInt(id));
            RecipientVM vm = new RecipientVM(recipient);
            if (recipient == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Recipients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _recipientService.DeactivateRecipient(id);
            return RedirectToAction("Index");
        }
    }
}
