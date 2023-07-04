using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCore.Model
{
    /// <summary>
    /// Thông tin session
    /// </summary>
    public class Session : BaseDTO
    {
        public Guid? UserID { get; set; }
        public Guid? SessionID { get; set; }
        public DateTime? ExpiredDate { get; set; }

    }
}
