using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLayer.Interfaces
{
    public interface ILogFactory
    {
        ILog NewLog(
        int Id, 
        DateTime Date, 
        string Thread, 
        string Level, 
        string Logger,
        string Message,
        string Exception); 
    }
}
