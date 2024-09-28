using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Helpers
{
    public static class Helper
    {
        public static string GetLogFilePath()
        {
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            return Path.Combine(AppContext.BaseDirectory, "logs", $"log-{date}.txt");
        }
    }
}
