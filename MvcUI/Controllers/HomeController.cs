using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModelLayer.Interfaces.Recipient;
using ViewModelLayer.Models;

namespace MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecipientService _recipientService;
        public HomeController(IRecipientService recipientService)
        {
            _recipientService = recipientService;
        }

        public ActionResult Index()
        {
            this._recipientService.CreateRecepient(new Recipient()
            {
                Account = "43749928388829",
                Active = true,
                Address = "Bulowice ulica błotna numer zachlapany",
                CompanyName = "Tauron",
                CustomerServiceUrl = "www.dupa.pl"
            });
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}