using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Repositories.Child
{
    public class UnitOfWork : IUnitOfWork
    {
        private CompanyRepo companyRepo;
        public InventoryContext _context;
        public UnitOfWork(InventoryContext context)
        {
            _context = context;
            
        }
        public CompanyRepo CompanyRepo
        {
            get
            {
                if (companyRepo == null)
                {
                    companyRepo = new CompanyRepo(_context);
                }
                return companyRepo;

            }
        }

        public CompanyBranchRepo companyBranchRepo;
        public CompanyBranchRepo CompanyBranchRepo
        {
            get
            {
                if (companyBranchRepo == null)
                {
                    companyBranchRepo = new CompanyBranchRepo(_context);
                }
                return companyBranchRepo;
            }
        }
        public string save()
        {
            if (_context.SaveChanges() > 0)
            {
                return "success";
            }
            else
            {
                return "failed";
            }
        }
    }
}
