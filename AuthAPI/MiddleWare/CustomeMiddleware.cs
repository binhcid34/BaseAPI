using AuthCore.Common;
using AuthCore.Model;
using AuthCore.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.MiddleWare
{
    public class CustomeMiddleware
    {
        private readonly RequestDelegate _next;
        IContextWrapper _IContextWrapper;
        ISessionService _ISessionService;
        IUserService _IUserService;

        public CustomeMiddleware(RequestDelegate next, IContextWrapper contextWrapper, ISessionService sessionService, IUserService iUserService)
        {
            _next = next;
            _IContextWrapper = contextWrapper;
            _ISessionService = sessionService;
            _IUserService = iUserService;
        }

        public async Task Invoke(HttpContext context)
        {
            // get SSID from Request
            var ssid = _IContextWrapper.GetValueFromRequest("SSID", "");
            ssid = "c7805bc4-4592-42e6-ab71-d861cefa1bc0";
            if (!String.IsNullOrEmpty(ssid))
            {
                // attach ContextUser
                await AttachUser(ssid, context);
            }
            await _next(context);
        }
        private async Task AttachUser(string ssid, HttpContext context)
        {
            // check expired
            var userID = _ISessionService.checkSession(ssid);
            User curentUser = null;
            if (userID != null)
            {
                curentUser = await _IUserService.getUserByUserID(userID);
            }
            context.Items["User"] = curentUser;

        }
    }
}
