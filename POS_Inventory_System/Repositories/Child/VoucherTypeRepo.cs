using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Repositories.Child
{
    public interface IVoucherTypeRepo:IGenericRepo<VoucherType>
    {

    }
    public class VoucherTypeRepo : GenericRepo<VoucherType>, IVoucherTypeRepo
    {
        public VoucherTypeRepo(InventoryContext context) : base(context)
        {
        }
    }
}
