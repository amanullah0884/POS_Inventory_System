using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Repositories.Child
{
    public interface IItemRepo : IGenericRepo<Item>
    {

    }
    public class ItemRepo : GenericRepo<Item>, IItemRepo
    {
        public ItemRepo(InventoryContext context) : base(context)
        {
        }
    }
}
