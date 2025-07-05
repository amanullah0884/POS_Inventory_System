using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Repositories.Child
{
    public interface ICompanyBranchRepo : IGenericRepo<CompanyBranch>
    {

    }
    public class CompanyBranchRepo : GenericRepo<CompanyBranch>, ICompanyBranchRepo
    {
        public CompanyBranchRepo(InventoryContext context) : base(context)
        {
        }

        public async Task Add(Country country)
        {
            throw new NotImplementedException();
        }
    }
}
