using HappyWarehouse.App.Models.Item;
using HappyWarehouse.App.Models.User;
using HappyWarehouse.App.Models.Warehouse;
using HappyWarehouse.Core.Entities;
using HappyWarehouse.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Services.Impl
{
    public class ItemService : IItemService
    {
        private readonly IBaseRepository<Item> _itemRepository;
        private readonly UserContext _userContext;
        public ItemService(IBaseRepository<Item> itemRepository, UserContext userContext)
        {
            _itemRepository = itemRepository;
            _userContext = userContext;
        }

        public async Task<bool> AddItem(AddItemModel model)
        {
            var item = new Item
            {
                Name = model.Name.Trim(),
                CostPrice = model.CostPrice,
                MSRPPrice = model.MSRPPrice,
                Quantity = model.Quantity,
                SKUName = model.SKUName,
                WarehouseId = model.WarehouseId,
                IsDeleted = false,
                CreatedBy = _userContext.Id,
                CreationOn = DateTime.Now,
            };

            var isUnique = await _itemRepository.CheckUnique(x=>x.Name.ToLower() == model.Name.ToLower());
            if (!isUnique)
            {
                return false;
            }

            await _itemRepository.AddAsync(item);
            return true;
        }

        public async Task<bool> DeleteItem(int id)
        {
            await _itemRepository.DeleteAsync(id);
            return true;
        }

        public async Task<EditItemModel?> GetItemById(int id)
        {
            var item = await _itemRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return null;
            }

            return new EditItemModel
            {
                Id = item.Id,
                Name = item.Name,
                SKUName = item.SKUName,
                Quantity = item.Quantity,
                MSRPPrice = item.MSRPPrice,
                CostPrice = item.CostPrice,
            };
        }

        public async Task<List<EditItemModel>> GetItemsByWarehouseId(int warehouseId)
        {
            var item = _itemRepository.GetAllInclude(x => x.WarehouseId == warehouseId && !x.IsDeleted, new List<Expression<Func<Item, object>>> { x => x.Warehouse }, false);

            return item.Select(w => new EditItemModel
            {
                Id = w.Id,
                Name = w.Name,
                CostPrice = w.CostPrice,
                MSRPPrice = w.MSRPPrice,
                Quantity = w.Quantity,
                SKUName = w.SKUName,
                CreatedBy = w.CreatedBy,
                CreationOn = w.CreationOn,
                IsDeleted = w.IsDeleted,
                ModificationDate = w.ModificationDate,
                Warehouse = w.Warehouse.Name,
                WarehouseId = w.WarehouseId,
            }).ToList();
        }

        public async Task<bool> UpdateItem(EditItemModel item)
        {
            var itemUpdateEntity = new Item
            {
                Id = item.Id,
                Name = item.Name,
                WarehouseId = item.WarehouseId,
                CostPrice = item.CostPrice,
                MSRPPrice = item.MSRPPrice,
                SKUName = item.SKUName,
                Quantity = item.Quantity,
                ModificationDate = DateTime.Now,
                IsDeleted = item.IsDeleted,
                CreationOn = item.CreationOn,
                CreatedBy = item.CreatedBy
            };

            await _itemRepository.UpdateAsync(itemUpdateEntity);
            return true;
        }
    }
}
