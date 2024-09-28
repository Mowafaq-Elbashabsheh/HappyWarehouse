using HappyWarehouse.App.Models.User;
using System.Security.Claims;

namespace HappyWarehouse.API.Middleware
{
    public class UserContextMiddleware
    {
        private readonly RequestDelegate _next;

        public UserContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserContext userContext)
        {
            userContext.Id = Convert.ToInt32(context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            userContext.Role = context.User?.FindFirst(ClaimTypes.Role)?.Value;
            await _next(context);
        }

    }
}
