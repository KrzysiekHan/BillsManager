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

        public RecipientsController(IRecipientService recipientService, IRecipientFactory recipientFactory)
        {
            _recipientService = recipientService;
            _recipientFactory = recipientFactory;
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
            if (recipient == null)
            {
                return HttpNotFound();
            }
            return View(recipient);
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
        public ActionResult Create([Bind(Include = "RecipientId,CompanyName,Address,Account,CustomerServiceUrl,Active")] Recipient recipient)
        {
            if (ModelState.IsValid)
            {
                IRecipient item = _recipientFactory.NewRecipient(recipient.RecipientId, recipient.CompanyName, recipient.Address, recipient.Account, recipient.CustomerServiceUrl, recipient.Active);
                _recipientService.CreateRecepient(item);
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
        public ActionResult Edit([Bind(Include = "RecipientId,CompanyName,Address,Account,CustomerServiceUrl,Active")] IRecipient recipient)
        {
            if (ModelState.IsValid)
            {
                _recipientService.UpdateRecepient(recipient);
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
            if (recipient == null)
            {
                return HttpNotFound();
            }
            return View(recipient);
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
