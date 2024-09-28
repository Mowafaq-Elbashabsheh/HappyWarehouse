using HappyWarehouse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Models.User
{
    public class LoginUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseModel
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string ErrorMessage { get; set; }
    }
}
