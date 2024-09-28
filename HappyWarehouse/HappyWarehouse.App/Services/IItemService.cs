using HappyWarehouse.App.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Services
{
    public interface IItemService
    {
        Task<List<EditItemModel>> GetItemsByWarehouseId(int warehouseId);
        Task<EditItemModel?> GetItemById(int id);
        Task<bool> AddItem(AddItemModel model);
        Task<bool> UpdateItem(EditItemModel warehouse);
        Task<bool> DeleteItem(int id);
    }
}
