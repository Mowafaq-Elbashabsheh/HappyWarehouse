using HappyWarehouse.App.Helpers;
using HappyWarehouse.App.Models.Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Services.Impl
{
    public class AdminService : IAdminService
    {
        public async Task<List<LogsFormat>> GetLogsAsync()
        {
            var filePath = Helper.GetLogFilePath();
            
            var logs = new List<LogsFormat>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if(string.IsNullOrEmpty(line)) continue;

                    if (line.Contains("Log created on")) continue;

                    var log = JsonSerializer.Deserialize<LogsFormat>(line);
                    if(log != null)
                    {
                        logs.Add(log);
                    }
                }
            }

            return logs;
        }
    }
}
