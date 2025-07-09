using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Repositories.Child
{
    public interface ISupplierAddressRepo : IGenericRepo<SupplierAddress>
    {

    }
    public class SupplierAddressRepo : GenericRepo<SupplierAddress>, ISupplierAddressRepo
    {
        public SupplierAddressRepo(InventoryContext context) : base(context)
        {
        }
    }
}
