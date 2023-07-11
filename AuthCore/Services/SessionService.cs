using AuthCore.Model;
using Dapper;
using Infracstructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Cache;
using WebCore.Extension.Log;
using WebCore.Services.BaseService;
using WebCore.Shared.Constants;

namespace AuthCore.Services
{
    public class SessionService : BaseService, ISessionService
    {
        public IBaseRepository<Session> _IBaseRepository;
        public SessionService(IBaseRepository<Session> iBaseRepository, ICacheService cacheService, ILogService logService): base(cacheService, logService)
        {
            _IBaseRepository = iBaseRepository;
        }

        public string checkSession(string sessionID)
        {
            // init key cache
            string key = CacheKeys.SESSIONID + "_" + sessionID;
            // get cache
            var session = new Session();
             _cacheService.TryGetValue(key,out session);
            _logService.addLogService(this.GetType().ToString(), LogKey.LogInfo, $"Get key from {sessionID} ");
            
            if (session == null || String.IsNullOrEmpty(session.UserID.ToString())) {
                string query = $"SELECT * FROM session WHERE sessionID='{sessionID}'";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("v_SessionID", sessionID);
                session = _IBaseRepository.ExcuteCommandLine(query);
                if (session == null)
                {
                    return string.Empty;
                }
                _cacheService.SetCache(key, session, 5,10, 240);
            }
            if (session.ExpiredDate < DateTime.Now)
            {
                return string.Empty;
            }
            return session.UserID.ToString();
        }
    }
}
