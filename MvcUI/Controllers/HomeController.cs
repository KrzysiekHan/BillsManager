using MvcUI.Common;
using MvcUI.Models.Home;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModelLayer.Interfaces.Bill;
using ViewModelLayer.Interfaces.Recipient;
using ViewModelLayer.Models;

namespace MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecipientService _recipientService;
        private readonly IBillService _billService;

        public HomeController(IRecipientService recipientService, IBillService billService)
        {
            _recipientService = recipientService;
            _billService = billService;
        }

        public ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.Months = GetLastMonthsNames(DateTime.Now);
            homeViewModel.ChartDataSets = GetChartDataSets(DateTime.Now);
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

        private List<string> GetLastMonthsNames(DateTime dt)
        {
            List<string> response = new List<string>();

            for (int i = 6; i >= 0; i--)
            {
                string month = dt.AddMonths(-i).ToString("MMMM", CultureInfo.CreateSpecificCulture("pl"));
                response.Add(month);
            }
            foreach (var item in response)
            {
                CommonFunctions.FirstCharToUpper(item);
            }
            return response;
        }

        private List<ChartDataSet> GetChartDataSets(DateTime dt)
        {

            List<ChartDataSet> ReturnList = new List<ChartDataSet>();

            return ReturnList;
        }

        public void GetLastSixBillsForRecipient(int RecipientId)
        {


        }
    }

    public class MonthData
    {
        public MonthData(IEnumerable<ViewModelLayer.Interfaces.IBill> bills)
        {
            foreach (var item in bills)
            {
                this.MonthlyBills.Add(item.Recipient.CompanyName.ToString(), item.DueAmount);
            }
        }
        public Dictionary<string,decimal> MonthlyBills { get; set; }
    }
}