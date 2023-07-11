using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Shared.Constants;

namespace WebCore.Extension.Log
{
    public interface ILogService
    {
        public void addLogService(string key, string level = LogKey.LogInfo, string message = "");
    }
}
