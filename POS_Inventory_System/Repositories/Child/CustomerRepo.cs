using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Repositories.Child
{
    public interface ICustmerRepo :IGenericRepo<Customer>
    {

    }
    public class CustomerRepo : GenericRepo<Customer>, ICustmerRepo
    {
        public CustomerRepo(InventoryContext context) : base(context)
        {
        }
    }
}
