using AuthCore.Model;
using Dapper;
using Infracstructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Model;
using WebCore.Services.BaseService;

namespace WebCore.Extension.Log
{
    public class LogService : ILogService
    {
        public IBaseRepository<Logging> _IbaseRepository;

        public LogService(IBaseRepository<Logging> IbaseRepository)
        {
            _IbaseRepository = IbaseRepository;
        }
        public void addLogService(string key, string level = "LogInfo", string message = "")
        {
            var sessionID = Guid.NewGuid();
            // thêm vòa bảng sesion
            var proc = "Proc_Logging_Insert";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("v_Key", key);
            parameters.Add("v_Level", level);
            parameters.Add("v_Message", message);
            _IbaseRepository.ExcuteProcedure(proc, parameters);
        }
    }
}
