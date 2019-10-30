using MvcUI.Models.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModelLayer.Interfaces;

namespace MvcUI.Controllers
{
    public class HistoryController : Controller
    {
        private readonly ILogService _logService;

        public HistoryController(ILogService logService)
        {
            _logService = logService;
        }
        // GET: History
        public ActionResult Index()
        {
            HistoryVM historyVM = new HistoryVM();
            List<LogVM> logs = new List<LogVM>();
            historyVM.logs = logs;
            IEnumerable<ILog> response = _logService.GetAllLogs();
            if (response != null)
            {
                foreach (var item in response)
                {
                    LogVM logVM = new LogVM(item.Id, item.Date, item.Thread, item.Level, item.Message);
                    historyVM.logs.Add(logVM);
                }
            }

            return View(historyVM);
        }
    }
}