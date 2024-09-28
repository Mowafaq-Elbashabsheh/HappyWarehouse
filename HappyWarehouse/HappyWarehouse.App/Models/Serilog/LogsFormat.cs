using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Models.Serilog
{
    public class LogsFormat
    {
        public string TraceId { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
    }
}
