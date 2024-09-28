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
    [Authorize(Roles="Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("GetLogs")]
        public async Task<IActionResult> GetLogs()
        {
            try
            {
                var logs = await _adminService.GetLogsAsync();
                return Ok(logs);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
