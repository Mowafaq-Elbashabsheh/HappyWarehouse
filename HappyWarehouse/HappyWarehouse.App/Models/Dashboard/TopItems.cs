using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Models.Dashboard
{
    public class TopItems
    {
        public List<ItemsQuantity> MaxItems { get; set; }
        public List<ItemsQuantity> MinItems { get; set; }
    }
}
