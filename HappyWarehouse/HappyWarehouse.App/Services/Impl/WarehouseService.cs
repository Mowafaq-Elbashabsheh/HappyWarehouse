using HappyWarehouse.App.Models.Warehouse;
using HappyWarehouse.Core.Entities;
using HappyWarehouse.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using HappyWarehouse.App.Models.User;

namespace HappyWarehouse.App.Services.Impl
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IBaseRepository<Warehouse> _warehouseRepository;
        private readonly UserContext _userContext;
        public WarehouseService(IBaseRepository<Warehouse> warehouseRepository, UserContext userContext)
        {
            _warehouseRepository = warehouseRepository;
            _userContext = userContext;
        }

        public async Task<bool> AddWarehouse(AddWarehouseModel model)
        {
            var warehouse = new Warehouse {
                Name = model.Name.Trim(),
                City = model.City,
                Address = model.Address,
                CountryId = model.CountryId,
                IsDeleted = false,
                CreatedBy = _userContext.Id,
                CreationOn = DateTime.Now,
            };

            var isUnique = await _warehouseRepository.CheckUnique(x=>x.Name.ToLower() == model.Name.ToLower());
            if(!isUnique)
            {
                return false;
            }

            await _warehouseRepository.AddAsync(warehouse);
            return true;
        }

        public async Task<bool> DeleteWarehouse(int id)
        {
            await _warehouseRepository.DeleteAsync(id);
            return true;
        }

        public async Task<List<EditWarehouseModel>> GetAllWarehouses()
        {
            var warehouses = _warehouseRepository.GetAllInclude(x=>!x.IsDeleted, new List<Expression<Func<Warehouse, object>>> { x=>x.Country }, false);

            return warehouses.Select(w => new EditWarehouseModel
            {
                Id = w.Id,
                Name = w.Name,
                Country = w.Country.Name,
                City = w.City,
                Address = w.Address,
                CountryId = w.CountryId,
                CreatedBy = w.CreatedBy,
                CreationOn = w.CreationOn,
                IsDeleted = w.IsDeleted,
                ModificationDate = w.ModificationDate,
            }).ToList();
        }

        public async Task<EditWarehouseModel?> GetWarehouseById(int id)
        {
            var warehouse =  await _warehouseRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            if (warehouse == null)
            {
                return null;
            }

            return new EditWarehouseModel { 
                Id = warehouse.Id,
                Name = warehouse.Name,
                Address = warehouse.Address, 
                CountryId = warehouse.CountryId, 
                City = warehouse.City,
                Country = warehouse.Country.Name,
            };
        }

        public async Task<bool> UpdateWarehouse(EditWarehouseModel warehouse)
        {
            var warehouseUpdateEntity = new Warehouse
            {
                Name = warehouse.Name,
                Id = warehouse.Id,
                CountryId = warehouse.CountryId,
                Address = warehouse.Address,
                City = warehouse.City,
                ModificationDate = DateTime.Now,
                IsDeleted = warehouse.IsDeleted,
                CreationOn = warehouse.CreationOn,
                CreatedBy = warehouse.CreatedBy
            };

            await _warehouseRepository.UpdateAsync(warehouseUpdateEntity);
            return true;
        }
    }
}
