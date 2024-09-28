using HappyWarehouse.Core.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.Core.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public short RoleId { get; set; }
        public Role Role { get; set; }
        public bool Active { get; set; }
    }
}
