using HappyWarehouse.App.Models.Warehouse;
using HappyWarehouse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Services
{
    public interface IWarehouseService
    {
        Task<List<EditWarehouseModel>> GetAllWarehouses();
        Task<EditWarehouseModel?> GetWarehouseById(int id);
        Task<bool> AddWarehouse(AddWarehouseModel model);
        Task<bool> UpdateWarehouse(EditWarehouseModel warehouse); 
        Task<bool> DeleteWarehouse(int id);
    }
}
