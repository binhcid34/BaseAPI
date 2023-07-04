using AuthAPI.Filters;
using AuthCore.Model;
using AuthCore.Services;
using Infracstructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCore.Model;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public IBaseRepository<User> _IBaseRepository;
        public IUserService _IUserService;
        public AuthController  ( IBaseRepository<User> baseRepository, IUserService userService)
        {
            _IBaseRepository = baseRepository;
            _IUserService = userService;
        }

      [HttpGet]
       public async Task<IActionResult> checkPermision()
        {
            return OkCustomeResult(null);
        }

        [HttpGet("user")]
        public async Task<ServiceResponse> getAllUser()
        {
            var res = new ServiceResponse();
            try
            {
                var data = _IBaseRepository.GetAll();
                return res.OnSuccess(data);
            } catch (Exception ex)
            {
                return res.OnException(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ServiceResponse> login(string userName, string password)
        {
            var res = new ServiceResponse();
            try
            {
                var data = _IUserService.Login(userName, password).Result;
                if (data == null)
                {
                    return res.OnError(data, "UserName or Password invalid");
                }
                return res.OnSuccess(data);
            }
            catch (Exception ex)
            {
                return res.OnException(ex.Message);
            }
        }

        [HttpGet("logout")]
        public async Task<ServiceResponse> logout()
        {
            var res = new ServiceResponse();
            try
            {
                return res;
            } catch  (Exception ex)
            {
                return res.OnException(ex.Message);
            }
        }
    }
}
