using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLayer.Interfaces
{
    public interface ILog
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        string Thread { get; set; }
        string Level { get; set; }
        string Logger { get; set; }
        string Message { get; set; }
        string Exception { get; set; }
    }
}
