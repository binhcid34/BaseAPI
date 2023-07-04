using AuthCore.Model;
using Infracstructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCore.Services
{
    public class SessionService : ISessionService
    {
        private IBaseRepository<Session> _IBaseRepository;

        public SessionService(IBaseRepository<Session> iBaseRepository)
        {
            _IBaseRepository = iBaseRepository;
        }

        public string checkSession(string sessionID)
        {
            var session = _IBaseRepository.ExcuteCommandLine(sessionID);
            if (session == null)
            {
                return null;
            }
            if (session.ExpiredDate > DateTime.Now) {
                return null;
            }
            return session.UserID.ToString();
        }
    }
}
