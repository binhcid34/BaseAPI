using AuthAPI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : BaseController
    {
        [HttpGet]
        [AuthAttribute("admin")]
        public IActionResult CheckLogin() {
            return Ok(CurrentUser);
        }
    }
}
