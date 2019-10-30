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
        private readonly ILogRepository _repository;
        private readonly IFactory _factory;

        public LogService(ILogRepository logRepository, IFactory factory)
        {
            _repository = logRepository;
            _factory = factory;
        }

        public void DeleteAllLogs()
        {
            _repository.DeleteAllLogs();
        }

        public IEnumerable<ILog> GetAllLogs() {
            var response = _repository.GetAll();
            foreach (var item in response)
            {
                yield return _factory.LogFactory.NewLog(item.Id, item.Date, item.Thread, item.Level, item.Logger, item.Message, item.Exception);
            }
        }
    }
}
