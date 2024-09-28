using HappyWarehouse.App.Models.Warehouse;
using HappyWarehouse.App.Services;
using HappyWarehouse.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HappyWarehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet("GetAllWarehouses")]
        public async Task<IActionResult> GetAllWarehouses()
        {
            try
            {
                var warehouses = await _warehouseService.GetAllWarehouses();

                return Ok(warehouses);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("AddWarehouse")]
        public async Task<IActionResult> AddWarehouse(AddWarehouseModel warehouse)
        {
            try
            {
                var warehouses = await _warehouseService.AddWarehouse(warehouse);

                return Ok(warehouses);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("EditWarehouse")]
        public async Task<IActionResult> EditWarehouse(EditWarehouseModel warehouse)
        {
            try
            {
                var warehouses = await _warehouseService.UpdateWarehouse(warehouse);

                return Ok(warehouses);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("DeleteWarehouse")]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            try
            {
                var warehouses = await _warehouseService.DeleteWarehouse(id);

                return Ok(warehouses);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
