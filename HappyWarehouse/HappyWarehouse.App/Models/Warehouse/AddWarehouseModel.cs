using HappyWarehouse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Models.Warehouse
{
    public class AddWarehouseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public short CountryId { get; set; }
    }
}
