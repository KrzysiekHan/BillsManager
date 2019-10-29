using DbAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Interfaces;

namespace ViewModelLayer.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _ILogRepository;
        private readonly IFactory _factory;

        public LogService(ILogRepository logRepository, IFactory factory)
        {
            _ILogRepository = logRepository;
            _factory = factory;
        }

        public IEnumerable<ILog> GetAllLogs() {
            var response = _ILogRepository.GetAll();
            foreach (var item in response)
            {
                yield return _factory.LogFactory.NewLog(item.Id, item.Date, item.Thread, item.Level, item.Logger, item.Message, item.Exception);
            }
        }
    }
}
