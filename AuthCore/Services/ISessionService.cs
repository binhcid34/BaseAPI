using AuthCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCore.Services
{
    public interface ISessionService
    {
        public string checkSession(string sessionID);
    }
}
