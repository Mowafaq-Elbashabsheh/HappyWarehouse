using HappyWarehouse.App.Models.Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Services
{
    public interface IAdminService
    {
        Task<List<LogsFormat>> GetLogsAsync();
    }
}
