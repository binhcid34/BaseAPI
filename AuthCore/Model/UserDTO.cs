using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCore.Model
{
    /// <summary>
    /// Thông tin người dùng
    /// </summary>
    public class User : BaseDTO
    {
        public Guid? UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
