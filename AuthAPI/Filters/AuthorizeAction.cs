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
        private readonly string _roleType;
        private IContextWrapper _IContextWrapper;
        private ISessionService _ISessionService;
        private IUserService _IUserService;
        private HttpContext _context;
        public AuthorizeAction( string roleType, IContextWrapper contextWrapper, IUserService userService)
        {
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
            // check currentUser in HttpContext
            var currentUser = context.HttpContext.Items["User"];
            if (currentUser == null)
            {
                this.errorValidSession(context);
            }
            // check role
            if (!String.IsNullOrEmpty(_roleType))
            {
                
            }
        }
        private void errorValidSession(ActionExecutingContext context)
        {
            context.Result  = new JsonResult( new { Message = "Login_Again", SubCode = 99, Success = false});
        }
    }
}
