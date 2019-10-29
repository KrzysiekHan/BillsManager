using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLayer.Interfaces
{
    public interface ILogService
    {
        IEnumerable<ILog> GetAllLogs();
    }
}
