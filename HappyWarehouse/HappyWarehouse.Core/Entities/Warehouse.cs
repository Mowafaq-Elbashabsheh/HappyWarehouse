using HappyWarehouse.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.Core.Entities
{
    public class Warehouse : BaseEntity
    {
        public Warehouse()
        {
            Items = new HashSet<Item>();
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public short CountryId { get; set; }
        public Country Country { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
