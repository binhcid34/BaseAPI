using AuthCore.Common;
using AuthCore.Model;
using AuthCore.Services;
using Infracstructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using WebCore.Common;

namespace AuthAPI.Filters
{
    public class AuthorizeAction : IActionFilter
    {
        private readonly string _actionName;
        private readonly string _roleType;
        private IContextWrapper _IContextWrapper;
        private ISessionService _ISessionService;
        private IUserService _IUserService;
        public AuthorizeAction(string actionName, string roleType, IContextWrapper contextWrapper, IUserService userService)
        {
            _actionName = actionName;
            _roleType = roleType;
            _IContextWrapper = contextWrapper;
            _IUserService= userService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("output");
            
        }

        /// <summary>
        /// Kiểm tra đầu vào
        /// </summary>
        /// <param name="context"></param>
        public async void OnActionExecuting(ActionExecutingContext context)
        {
            if (_actionName == "login")
            {
               var ssid =  _IContextWrapper.GetValueFromRequest("SSID", "");
                if (String.IsNullOrEmpty(ssid))
                {

                    this.errorValidSession(context);
                }
                // Kiểm tra xem sesion hợp lệ không
                var userID = _ISessionService.checkSession(ssid);
                if (userID == null)
                {
                    this.errorValidSession(context);
                }
                else
                {
                    // Get current User
                    User curentUser = await _IUserService.getUserByUserID(userID);
                    if (curentUser == null)
                    {
                        this.errorValidSession(context);
                    }
                    //_IContextWrapper.Set("userID", curentUser.UserID.ToString(), 180);
                }

            }
            Console.WriteLine("input");
        }
        private void errorValidSession(ActionExecutingContext context)
        {
            context.Result  = new JsonResult("Login_Again");
        }
    }
}
