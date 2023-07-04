using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCore.Common
{
    /// <summary>
    /// Define class get value header and set header response
    /// </summary>
    public class ContextWrapper : IContextWrapper
    {

        private readonly IHttpContextAccessor _IHttpContextAccessor;

        public ContextWrapper (IHttpContextAccessor httpContextAccessor)
        {
            _IHttpContextAccessor = httpContextAccessor;
        }
        public string GetValueFromRequest(string key, string defaultvalue)
        {
            if (_IHttpContextAccessor.HttpContext.Request.Headers.TryGetValue(key, out StringValues headerValues) && headerValues.Any())
            {
                return headerValues.First();
            }
            return defaultvalue;
        }

        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            _IHttpContextAccessor.HttpContext.Response.Cookies.Append(key, value, option);
        }
    }
}
