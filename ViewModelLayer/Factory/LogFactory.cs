
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Interfaces;
using ViewModelLayer.Models;

namespace ViewModelLayer.Factory
{
    public class LogFactory : ILogFactory
    {
        public ILog NewLog(int Id, DateTime Date, string Thread, string Level, string Logger, string Message, string Exception)
        {
            return new Log()
            {
                Id = Id,
                Date = Date,
                Exception = Exception,
                Level = Level,
                Logger = Logger,
                Message = Message,
                Thread = Thread
            };
        }
    }
}
