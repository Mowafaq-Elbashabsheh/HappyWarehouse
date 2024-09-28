using HappyWarehouse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Models.User
{
    public class EditUserModel
    {
        public int Id { get; set; }
        public DateTime CreationOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public short RoleId { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }
    }
}
