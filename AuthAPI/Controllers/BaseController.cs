using AuthCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public User? CurrentUser => (User)HttpContext.Items["CurrentUser"];

        protected IActionResult OkCustomeResult(object? obj)
        {
            return StatusCode(200, obj);
        } 
    }
}
