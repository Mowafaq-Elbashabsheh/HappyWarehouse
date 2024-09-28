using HappyWarehouse.App.Models.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Services
{
    public interface IDashboardService
    {
        Task<TopItems> GetTopItems();
        Task<List<WarehouseStatus>> GetWarehouseStatus();
    }
}
