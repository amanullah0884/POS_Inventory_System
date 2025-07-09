using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Child;

namespace POS_Inventory_System.Repositories.Base
{
    public interface IUnitOfWork
    {
        CompanyRepo CompanyRepo { get; }
        CompanyBranchRepo CompanyBranchRepo { get; }
        CountryRepo CountryRepo { get; }
        BrandRepo BrandRepo { get; }
        ItemRepo ItemRepo { get; }
        ModelRepo ModelRepo { get; }
        ColorRepo ColorRepo { get; }
        PaymentMethodRepo PaymentMethodRepo { get; }
        ProductPackageRepo ProductPackageRepo { get; }
        PurchaseMastersRepo PurchaseMastersRepo { get; }
        SalesMasterRepo SalesMasterRepo { get; }
        SizeRepo SizeRepo { get; }
        UnitRepo UnitRepo { get; }
        SupplierAddressRepo SupplierAddressRepo { get; }
        VoucherTypeRepo VoucherTypeRepo { get; }
        VoucherTypewithComRepo VoucherTypewithComRepo { get; }
        CustomerRepo CustomerRepo { get; }
        StockMasterRepo StockMasterRepo { get; }

        string save();
    }
}
