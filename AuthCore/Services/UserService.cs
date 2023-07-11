using AuthCore.Common;
using AuthCore.Model;
using Dapper;
using Infracstructure.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCore.Services
{
    public class UserService : IUserService
    {
        private IBaseRepository<User> _IRepository;
        private IContextWrapper _IContextWrapper;

        public UserService(IBaseRepository<User> repository, IContextWrapper contextWrapper)
        {
            _IRepository = repository;
            _IContextWrapper = contextWrapper;
        }

       
        public async Task<User> Login(string username, string password)
        {
            var user = new User();
             user = await ValidateUser(username, password);
            if (user == null)
            {
                // login failed
                return null;
            }
            // Đăng nhập thành công sinh ra sesionID và trả về cho client thông qua cookie
            AfterLoginSuccess(user);
            return user;

        }

        private async Task<User> ValidateUser(string username, string password)
        {
            var proc = "Proc_User_Login";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("v_Username", username);
            parameters.Add("v_Password", password);
            var user = new User();
            user = _IRepository.ExcuteProcedure<User>(proc, parameters);
            return user;
        }
        private void AfterLoginSuccess(User user)
        {
            if (user != null && user.UserID != null)
            {
                var sessionID = Guid.NewGuid();
                // thêm vòa bảng sesion
                var proc = "Proc_Session_Insert";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("v_UserID", user.UserID);
                parameters.Add("v_SessionID", sessionID);
                parameters.Add("v_ExpiredTime", 180);
                _IRepository.ExcuteProcedure(proc, parameters);
                // trả về cookie
                _IContextWrapper.Set("SSID", sessionID.ToString(), 180);
            }
        }

        public void DeleteSession()
        {
            var ssid = _IContextWrapper.GetValueFromRequest("SSID", "");
            var query = $"DELETE FROM session WHERE SessionID = '{ssid}';";
            _IRepository.ExcuteCommandLine(query);
        }

        public async Task<User> getUserByUserID(string userID)
        {
            var query = $"Select *  FROM user WHERE UserID = '{userID}' limit 1;";
            return _IRepository.ExcuteCommandLine(query);
        }
    }
}
