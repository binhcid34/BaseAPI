using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Net;

namespace AuthAPI.Filters
{
    public class AuthAttribute : TypeFilterAttribute
    {
        public AuthAttribute(string roleType) : base(typeof(AuthorizeAction))
        {
            Arguments = new object[] {
            roleType
        };
        }
    }
}
