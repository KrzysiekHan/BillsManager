using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUI.Models.History
{
    public class LogVM
    {
        public LogVM( int Id, DateTime Date ,string Thread ,string Level, string Message )
        {
            this.Id = Id;
            this.Date = Date;
            this.Thread = Thread;
            this.Level = Level;
            this.Message = Message;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }
}