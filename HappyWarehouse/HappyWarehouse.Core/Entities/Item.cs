using HappyWarehouse.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.Core.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; } 
        public string? SKUName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Value must be at least 1.")]
        public int Quantity { get; set; } //Minimum 1
        public float CostPrice { get; set; } 
        public float? MSRPPrice { get; set; }
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
