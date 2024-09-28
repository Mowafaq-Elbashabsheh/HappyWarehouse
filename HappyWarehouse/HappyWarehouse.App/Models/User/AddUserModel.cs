using HappyWarehouse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Models.User
{
    public class AddUserModel
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public short RoleId { get; set; }
        public bool Active { get; set; }
    }
}
