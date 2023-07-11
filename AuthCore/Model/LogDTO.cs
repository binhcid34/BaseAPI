using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Model
{
    public class Logging
    {
        public int? ID { get; set; }
        public string Key { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public DateTime? TimeLog { get; set; }
    }
}
