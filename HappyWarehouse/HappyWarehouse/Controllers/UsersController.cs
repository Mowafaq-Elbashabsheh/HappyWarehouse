using HappyWarehouse.App.Models.User;
using HappyWarehouse.App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HappyWarehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginUserModel model)
        {
            try
            {
                var loginResponse = await _userService.LoginAsync(model);
                if (loginResponse == null)
                {
                    return Unauthorized(new { error = "Email or Password is not correct" });
                }
                return Ok(loginResponse);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();

                return Ok(users);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(AddUserModel user)
        {
            try
            {
                var users = await _userService.AddUser(user);

                return Ok(users);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser(EditUserModel user)
        {
            try
            {
                var users = await _userService.UpdateUser(user);

                return Ok(users);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var users = await _userService.DeleteUser(id);

                return Ok(users);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetError.");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
