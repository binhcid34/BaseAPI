using AuthCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCore.Services
{
    public interface IUserService
    {
        public Task<User> Login(string username, string password);

        public Task<User> getUserByUserID(string userID);

    }
}
