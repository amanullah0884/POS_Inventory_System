using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Repositories.Child
{
    public interface IPaymentMethodRepo  : IGenericRepo<PaymentMethod>
    {

    }
    public class PaymentMethodRepo : GenericRepo<PaymentMethod>, IPaymentMethodRepo
    {
        public PaymentMethodRepo(InventoryContext context) : base(context)
        {
        }
    }
}
