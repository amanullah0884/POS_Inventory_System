using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Repositories.Child
{
    public interface IBrandRepo :IGenericRepo<Brand>
    {

    }
    public class BrandRepo : GenericRepo<Brand>, IBrandRepo
    {
        public BrandRepo(InventoryContext context) : base(context)
        {
        }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
