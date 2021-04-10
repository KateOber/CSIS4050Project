using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMobileShopCodeFirstFromDB;

namespace TheMobileShopValidation
{
    public static class InventoryValidation
    {
        public static bool DataIsValid(this Inventory inventory)
        {
            return ( inventory.Name.Trim().Length != 0 || inventory.Brand.Trim().Length != 0 || inventory.Quantity != 0 ||
                inventory.Cost != 0 || inventory.Price != 0 || CategoryIsValid(inventory));
        }
        public static bool CategoryIsValid(this Inventory inventory)
        {
            using (TheMobileShopEntities context = new TheMobileShopEntities())
            {
                return context.Categories.Any(c => c.CategoryId == Int32.Parse(inventory.CategoryId));
            }
        }
    }
}
