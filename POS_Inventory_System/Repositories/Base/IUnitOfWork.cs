using POS_Inventory_System.Repositories.Child;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Repositories.Base
{
    public interface IUnitOfWork
    {
        public CompanyRepo CompanyRepo { get;  }
        public CompanyBranchRepo CompanyBranchRepo { get; }
        public CountryRepo CountryRepo { get; }
        public BrandRepo BrandRepo { get; }
        public ItemRepo ItemRepo { get; }
        string save();
    }
}
