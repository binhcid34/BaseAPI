using AuthCore.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Common
{
    public class ContextData
    {
        public User? currentUser { get; set; }
        public string ssid { get; set; }
        public HttpContext httpContext { get; set; }
    }
}
