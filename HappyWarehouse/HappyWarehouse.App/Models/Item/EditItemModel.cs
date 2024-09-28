using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Models.Item
{
    public class EditItemModel
    {
        public int Id { get; set; }
        public DateTime CreationOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string? SKUName { get; set; }
        public int Quantity { get; set; }
        public float CostPrice { get; set; }
        public float? MSRPPrice { get; set; }
        public int WarehouseId { get; set; }
        public string Warehouse { get; set; }
    }
}
