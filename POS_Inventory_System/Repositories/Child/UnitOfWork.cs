using POS_Inventory_System.Models;
using POS_Inventory_System.Repositories.Base;
using System;

namespace POS_Inventory_System.Repositories.Child
{
    public class UnitOfWork : IUnitOfWork
    {
        public InventoryContext _context;

        public UnitOfWork(InventoryContext context)
        {
            _context = context;
        }

        private CompanyRepo companyRepo;
        private CompanyBranchRepo companyBranchRepo;
        private CountryRepo countryRepo;
        private BrandRepo brandRepo;
        private ItemRepo itemRepo;
        private ModelRepo modelRepo;
        private ColorRepo colorRepo;
        private PaymentMethodRepo paymentMethod;
        private ProductPackageRepo productPackageRepo;
        private PurchaseMastersRepo purchaseMastersRepo;
        private SalesMasterRepo salesMasterRepo;
        private SizeRepo sizeRepo;
        private UnitRepo unitRepo;
        private SupplierAddressRepo supplierAddressRepo;
        private VoucherTypeRepo voucherTypeRepo;
        private VoucherTypewithComRepo voucherTypewithComRepo;
        private CustomerRepo customerRepo;
        private StockMasterRepo stockMasterRepo;

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

        public CountryRepo CountryRepo
        {
            get
            {
                if (countryRepo == null)
                {
                    countryRepo = new CountryRepo(_context);
                }
                return countryRepo;
            }
        }
        public StockMasterRepo StockMasterRepo
        {
            get
            {
                if (StockMasterRepo == null)
                {
                    stockMasterRepo = new StockMasterRepo(_context);
                }
                return StockMasterRepo;
            }
        }
        public ModelRepo ModelRepo
        {
            get
            {
                if (ModelRepo == null)
                {
                    modelRepo = new ModelRepo(_context);
                }
                return modelRepo;
            }
        }

        public BrandRepo BrandRepo
        {
            get
            {
                if (brandRepo == null)
                {
                    brandRepo = new BrandRepo(_context);
                }
                return brandRepo;
            }
        }

        public ItemRepo ItemRepo
        {
            get
            {
                if (itemRepo == null)
                {
                    itemRepo = new ItemRepo(_context);
                }
                return itemRepo;
            }
        }



        public ColorRepo ColorRepo
        {
            get
            {
                if (colorRepo == null)
                {
                    colorRepo = new ColorRepo(_context);
                }
                return colorRepo;
            }
        }
        public CustomerRepo CustomerRepo
        {
            get
            {
                if (CustomerRepo == null)
                {
                    customerRepo = new CustomerRepo(_context);
                }
                return customerRepo;
            }
        }

        public PaymentMethodRepo PaymentMethodRepo
        {
            get
            {
                if (paymentMethod == null)
                {
                    paymentMethod = new PaymentMethodRepo(_context);
                }
                return paymentMethod;
            }
        }

        public ProductPackageRepo ProductPackageRepo
        {
            get
            {
                if (productPackageRepo == null)
                {
                    productPackageRepo = new ProductPackageRepo(_context);
                }
                return productPackageRepo;
            }
        }

        public PurchaseMastersRepo PurchaseMastersRepo
        {
            get
            {
                if (purchaseMastersRepo == null)
                {
                    purchaseMastersRepo = new PurchaseMastersRepo(_context);
                }
                return purchaseMastersRepo;
            }
        }

        public SalesMasterRepo SalesMasterRepo
        {
            get
            {
                if (salesMasterRepo == null)
                {
                    salesMasterRepo = new SalesMasterRepo(_context);
                }
                return salesMasterRepo;
            }
        }

        public SizeRepo SizeRepo
        {
            get
            {
                if (sizeRepo == null)
                {
                    sizeRepo = new SizeRepo(_context);
                }
                return sizeRepo;
            }
        }

        public UnitRepo UnitRepo
        {
            get
            {
                if (unitRepo == null)
                {
                    unitRepo = new UnitRepo(_context);
                }
                return unitRepo;
            }
        }

        public SupplierAddressRepo SupplierAddressRepo
        {
            get
            {
                if (supplierAddressRepo == null)
                {
                    supplierAddressRepo = new SupplierAddressRepo(_context);
                }
                return supplierAddressRepo;
            }
        }

        public VoucherTypeRepo VoucherTypeRepo
        {
            get
            {
                if (voucherTypeRepo == null)
                {
                    voucherTypeRepo = new VoucherTypeRepo(_context);
                }
                return voucherTypeRepo;
            }
        }

        public VoucherTypewithComRepo VoucherTypewithComRepo
        {
            get
            {
                if (voucherTypewithComRepo == null)
                {
                    voucherTypewithComRepo = new VoucherTypewithComRepo(_context);
                }
                return voucherTypewithComRepo;
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



//using POS_Inventory_System.Models;
//using POS_Inventory_System.Repositories.Base;

//namespace POS_Inventory_System.Repositories.Child
//{
//    public class UnitOfWork : IUnitOfWork
//    {
//        public InventoryContext _context;

//        public UnitOfWork(InventoryContext context)
//        {
//            _context = context;
//        }

//        private CompanyRepo? companyRepo;
//        private CompanyBranchRepo? companyBranchRepo;
//        private CountryRepo? countryRepo;
//        private BrandRepo? brandRepo;
//        private ItemRepo? itemRepo;
//        private ModelRepo? modelRepo;
//        private ColorRepo? colorRepo;
//        private PaymentMethodRepo? paymentMethod;
//        private ProductPackageRepo? productPackageRepo;
//        private PurchaseMastersRepo? purchaseMastersRepo;
//        private SalesMasterRepo? salesMasterRepo;
//        private SizeRepo? sizeRepo;
//        private UnitRepo? unitRepo;
//        private SupplierAddressRepo? supplierAddressRepo;
//        private VoucherTypeRepo? voucherTypeRepo;
//        private VoucherTypewithComRepo? voucherTypewithComRepo;
//        private CustomerRepo? customerRepo;
//        private StockMasterRepo? stockMasterRepo;

//        public CompanyRepo CompanyRepo
//        {
//            get
//            {
//                if (companyRepo == null)
//                {
//                    companyRepo = new CompanyRepo(_context);
//                }
//                return companyRepo;
//            }
//        }

//        public CompanyBranchRepo CompanyBranchRepo
//        {
//            get
//            {
//                if (companyBranchRepo == null)
//                {
//                    companyBranchRepo = new CompanyBranchRepo(_context);
//                }
//                return companyBranchRepo;
//            }
//        }

//        public CountryRepo CountryRepo
//        {
//            get
//            {
//                if (countryRepo == null)
//                {
//                    countryRepo = new CountryRepo(_context);
//                }
//                return countryRepo;
//            }
//        }

//        public BrandRepo BrandRepo
//        {
//            get
//            {
//                if (brandRepo == null)
//                {
//                    brandRepo = new BrandRepo(_context);
//                }
//                return brandRepo;
//            }
//        }

//        public ItemRepo ItemRepo
//        {
//            get
//            {
//                if (itemRepo == null)
//                {
//                    itemRepo = new ItemRepo(_context);
//                }
//                return itemRepo;
//            }
//        }

//        public ModelRepo ModelRepo
//        {
//            get
//            {
//                if (modelRepo == null)
//                {
//                    modelRepo = new ModelRepo(_context);
//                }
//                return modelRepo;
//            }
//        }

//        public ColorRepo ColorRepo
//        {
//            get
//            {
//                if (colorRepo == null)
//                {
//                    colorRepo = new ColorRepo(_context);
//                }
//                return colorRepo;
//            }
//        }

//        public PaymentMethodRepo PaymentMethodRepo
//        {
//            get
//            {
//                if (paymentMethod == null)
//                {
//                    paymentMethod = new PaymentMethodRepo(_context);
//                }
//                return paymentMethod;
//            }
//        }

//        public ProductPackageRepo ProductPackageRepo
//        {
//            get
//            {
//                if (productPackageRepo == null)
//                {
//                    productPackageRepo = new ProductPackageRepo(_context);
//                }
//                return productPackageRepo;
//            }
//        }

//        public PurchaseMastersRepo PurchaseMastersRepo
//        {
//            get
//            {
//                if (purchaseMastersRepo == null)
//                {
//                    purchaseMastersRepo = new PurchaseMastersRepo(_context);
//                }
//                return purchaseMastersRepo;
//            }
//        }

//        public SalesMasterRepo SalesMasterRepo
//        {
//            get
//            {
//                if (salesMasterRepo == null)
//                {
//                    salesMasterRepo = new SalesMasterRepo(_context);
//                }
//                return salesMasterRepo;
//            }
//        }

//        public SizeRepo SizeRepo
//        {
//            get
//            {
//                if (sizeRepo == null)
//                {
//                    sizeRepo = new SizeRepo(_context);
//                }
//                return sizeRepo;
//            }
//        }

//        public UnitRepo UnitRepo
//        {
//            get
//            {
//                if (unitRepo == null)
//                {
//                    unitRepo = new UnitRepo(_context);
//                }
//                return unitRepo;
//            }
//        }

//        public SupplierAddressRepo SupplierAddressRepo
//        {
//            get
//            {
//                if (supplierAddressRepo == null)
//                {
//                    supplierAddressRepo = new SupplierAddressRepo(_context);
//                }
//                return supplierAddressRepo;
//            }
//        }

//        public VoucherTypeRepo VoucherTypeRepo
//        {
//            get
//            {
//                if (voucherTypeRepo == null)
//                {
//                    voucherTypeRepo = new VoucherTypeRepo(_context);
//                }
//                return voucherTypeRepo;
//            }
//        }

//        public VoucherTypewithComRepo VoucherTypewithComRepo
//        {
//            get
//            {
//                if (voucherTypewithComRepo == null)
//                {
//                    voucherTypewithComRepo = new VoucherTypewithComRepo(_context);
//                }
//                return voucherTypewithComRepo;
//            }
//        }

//        public CustomerRepo CustomerRepo
//        {
//            get
//            {
//                if (customerRepo == null)
//                {
//                    customerRepo = new CustomerRepo(_context);
//                }
//                return customerRepo;
//            }
//        }

//        public StockMasterRepo StockMasterRepo
//        {
//            get
//            {
//                if (stockMasterRepo == null)
//                {
//                    stockMasterRepo = new StockMasterRepo(_context);
//                }
//                return stockMasterRepo;
//            }
//        }

//        public string save()
//        {
//            return _context.SaveChanges() > 0 ? "success" : "failed";
//        }
//    }
//}



//using POS_Inventory_System.Models;
//using POS_Inventory_System.Repositories.Base;
//using System;

//namespace POS_Inventory_System.Repositories.Child
//{
//    public class UnitOfWork : IUnitOfWork
//    {
//        public InventoryContext _context;

//        public UnitOfWork(InventoryContext context)
//        {
//            _context = context;
//        }

//        private CompanyRepo companyRepo;
//        private CompanyBranchRepo companyBranchRepo;
//        private CountryRepo countryRepo;
//        private BrandRepo brandRepo;
//        private ItemRepo itemRepo;
//        private ModelRepo modelRepo;
//        private ColorRepo colorRepo;
//        private PaymentMethodRepo paymentMethod;
//        private ProductPackageRepo productPackageRepo;
//        private PurchaseMastersRepo purchaseMastersRepo;
//        private SalesMasterRepo salesMasterRepo;
//        private SizeRepo sizeRepo;
//        private UnitRepo unitRepo;
//        private SupplierAddressRepo supplierAddressRepo;
//        private VoucherTypeRepo voucherTypeRepo;
//        private VoucherTypewithComRepo voucherTypewithComRepo;
//        private CustomerRepo customerRepo;
//        private StockMasterRepo stockMasterRepo;

//        public CompanyRepo CompanyRepo
//        {
//            get
//            {
//                if (companyRepo == null)
//                {
//                    companyRepo = new CompanyRepo(_context);
//                }
//                return companyRepo;
//            }
//        }

//        public CompanyBranchRepo CompanyBranchRepo
//        {
//            get
//            {
//                if (companyBranchRepo == null)
//                {
//                    companyBranchRepo = new CompanyBranchRepo(_context);
//                }
//                return companyBranchRepo;
//            }
//        }

//        public CountryRepo CountryRepo
//        {
//            get
//            {
//                if (countryRepo == null)
//                {
//                    countryRepo = new CountryRepo(_context);
//                }
//                return countryRepo;
//            }
//        }
//        public StockMasterRepo StockMasterRepo
//        {
//            get
//            {
//                if (StockMasterRepo == null)
//                {
//                    stockMasterRepo = new StockMasterRepo(_context);
//                }
//                return StockMasterRepo;
//            }
//        }
//        public ModelRepo ModelRepo
//        {
//            get
//            {
//                if (ModelRepo == null)
//                {
//                    modelRepo = new ModelRepo(_context);
//                }
//                return modelRepo;
//            }
//        }

//        public BrandRepo BrandRepo
//        {
//            get
//            {
//                if (brandRepo == null)
//                {
//                    brandRepo = new BrandRepo(_context);
//                }
//                return brandRepo;
//            }
//        }

//        public ItemRepo ItemRepo
//        {
//            get
//            {
//                if (itemRepo == null)
//                {
//                    itemRepo = new ItemRepo(_context);
//                }
//                return itemRepo;
//            }
//        }



//        public ColorRepo ColorRepo
//        {
//            get
//            {
//                if (colorRepo == null)
//                {
//                    colorRepo = new ColorRepo(_context);
//                }
//                return colorRepo;
//            }
//        }
//        public CustomerRepo CustomerRepo
//        {
//            get
//            {
//                if (CustomerRepo == null)
//                {
//                    customerRepo = new CustomerRepo(_context);
//                }
//                return customerRepo;
//            }
//        }

//        public PaymentMethodRepo PaymentMethodRepo
//        {
//            get
//            {
//                if (paymentMethod == null)
//                {
//                    paymentMethod = new PaymentMethodRepo(_context);
//                }
//                return paymentMethod;
//            }
//        }

//        public ProductPackageRepo ProductPackageRepo
//        {
//            get
//            {
//                if (productPackageRepo == null)
//                {
//                    productPackageRepo = new ProductPackageRepo(_context);
//                }
//                return productPackageRepo;
//            }
//        }

//        public PurchaseMastersRepo PurchaseMastersRepo
//        {
//            get
//            {
//                if (purchaseMastersRepo == null)
//                {
//                    purchaseMastersRepo = new PurchaseMastersRepo(_context);
//                }
//                return purchaseMastersRepo;
//            }
//        }

//        public SalesMasterRepo SalesMasterRepo
//        {
//            get
//            {
//                if (salesMasterRepo == null)
//                {
//                    salesMasterRepo = new SalesMasterRepo(_context);
//                }
//                return salesMasterRepo;
//            }
//        }

//        public SizeRepo SizeRepo
//        {
//            get
//            {
//                if (sizeRepo == null)
//                {
//                    sizeRepo = new SizeRepo(_context);
//                }
//                return sizeRepo;
//            }
//        }

//        public UnitRepo UnitRepo
//        {
//            get
//            {
//                if (unitRepo == null)
//                {
//                    unitRepo = new UnitRepo(_context);
//                }
//                return unitRepo;
//            }
//        }

//        public SupplierAddressRepo SupplierAddressRepo
//        {
//            get
//            {
//                if (supplierAddressRepo == null)
//                {
//                    supplierAddressRepo = new SupplierAddressRepo(_context);
//                }
//                return supplierAddressRepo;
//            }
//        }

//        public VoucherTypeRepo VoucherTypeRepo
//        {
//            get
//            {
//                if (voucherTypeRepo == null)
//                {
//                    voucherTypeRepo = new VoucherTypeRepo(_context);
//                }
//                return voucherTypeRepo;
//            }
//        }

//        public VoucherTypewithComRepo VoucherTypewithComRepo
//        {
//            get
//            {
//                if (voucherTypewithComRepo == null)
//                {
//                    voucherTypewithComRepo = new VoucherTypewithComRepo(_context);
//                }
//                return voucherTypewithComRepo;
//            }
//        }

//        public string save()
//        {
//            if (_context.SaveChanges() > 0)
//            {
//                return "success";
//            }
//            else
//            {
//                return "failed";
//            }
//        }
//    }
//}