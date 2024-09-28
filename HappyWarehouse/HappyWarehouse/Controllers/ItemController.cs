using HappyWarehouse.App.Models.Item;
using HappyWarehouse.App.Models.Warehouse;
using HappyWarehouse.App.Services;
using HappyWarehouse.App.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HappyWarehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("GetItemsByWarehouseId")]
        public async Task<IActionResult> GetItemsByWarehouseId(int warehouseId)
        {
            try
            {
                var items = await _itemService.GetItemsByWarehouseId(warehouseId);

                return Ok(items);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItem(AddItemModel item)
        {
            try
            {
                var items = await _itemService.AddItem(item);

                return Ok(items);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("EditItem")]
        public async Task<IActionResult> EditItem(EditItemModel item)
        {
            try
            {
                var items = await _itemService.UpdateItem(item);

                return Ok(items);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("DeleteItem")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                var items = await _itemService.DeleteItem(id);

                return Ok(items);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
