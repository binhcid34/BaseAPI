using AuthAPI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthAttribute("login","1")]
    public class TestController : BaseController
    {
        [HttpGet]
        public IActionResult CheckLogin() {
            return Ok("check login");
        }
    }
}
