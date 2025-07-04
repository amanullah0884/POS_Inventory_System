using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Repositories.Child
{
    public interface ICompanyRepo
    {
        Task<List<CompanyInfo>> Getall(object value);
        Task GetAll(object value1, object value2);
    }

    public class CompanyRepo : GenericRepo<CompanyInfo>, ICompanyRepo
    {
        public CompanyRepo(InventoryContext context) : base(context)
        {
        }
    }
}
