using HappyWarehouse.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Models.Warehouse
{
    public class EditWarehouseModel
    {
        public int Id { get; set; }
        public DateTime CreationOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public short CountryId { get; set; }
        public string Country { get; set; }
    }
}
