using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCore.Common
{
    public interface IContextWrapper
    {
        string GetValueFromRequest(string key, string defaultvalue);
        void Set(string key, string value, int? expireTime);
    }
}
