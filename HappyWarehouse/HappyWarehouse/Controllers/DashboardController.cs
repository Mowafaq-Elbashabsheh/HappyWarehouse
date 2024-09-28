using HappyWarehouse.App.Models.User;
using HappyWarehouse.App.Services;
using HappyWarehouse.App.Services.Impl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HappyWarehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dasboardService;
        private readonly UserContext _userContext;
        public DashboardController(IDashboardService dasboardService, UserContext userContext)
        {
            _dasboardService = dasboardService;
            _userContext = userContext;
        }

        [HttpGet("GetTopItems")]
        public async Task<IActionResult> GetTopItems()
        {
            try
            {
                var topItems = await _dasboardService.GetTopItems();
                return Ok(topItems);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetWarehouseStatus")]
        public async Task<IActionResult> GetWarehouseStatus()
        {
            try
            {
                var warehouseStatuses = await _dasboardService.GetWarehouseStatus();
                return Ok(warehouseStatuses);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
