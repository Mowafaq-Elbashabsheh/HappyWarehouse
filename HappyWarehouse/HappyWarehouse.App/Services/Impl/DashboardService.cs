using HappyWarehouse.App.Models.Dashboard;
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
    public class DashboardService : IDashboardService
    {
        private readonly IBaseRepository<Warehouse> _warehouseRepository;
        private readonly IBaseRepository<Item> _itemRepository;
        public DashboardService(IBaseRepository<Warehouse> warehouseRepository, IBaseRepository<Item> itemRepository)
        {
            _warehouseRepository=warehouseRepository;
            _itemRepository=itemRepository;
        }

        public async Task<TopItems> GetTopItems()
        {
            TopItems topItems = new TopItems();

            var items = _itemRepository.GetAllInclude(x=>!x.IsDeleted);
            
            
            topItems.MinItems = items.OrderBy(x=>x.Quantity).Take(10)
                .Select(x => new ItemsQuantity { Name = x.Name, Quantity = x.Quantity}).ToList();

            topItems.MaxItems = items.OrderByDescending(x => x.Quantity).Take(10)
                .Select(x => new ItemsQuantity { Name = x.Name, Quantity = x.Quantity }).ToList();

            return topItems;
        }

        public async Task<List<WarehouseStatus>> GetWarehouseStatus()
        {
            var warehouseStatus = _warehouseRepository
                .GetAllInclude(x => !x.IsDeleted, new List<Expression<Func<Warehouse, object>>> { x => x.Items })
                .Select(x => new WarehouseStatus
                {
                    WarehouseName = x.Name,
                    ItemsCount = x.Items.Sum(x=>x.Quantity)
                    //if count of items categories ===>  ItemsCount = x.Items.count
                }).ToList();

            return warehouseStatus;
        }
    }
}
