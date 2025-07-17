using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class ApplicationUser : IdentityUser
    {

    }
    public class InventoryContext : IdentityDbContext<ApplicationUser>
    {
        public InventoryContext()
        {

        }
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }
        public DbSet<CompanyBranch> CompanyBranch { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Model> myModel {  get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<ProductPackage> ProductPackage { get; set; }
        public DbSet<PurchaseMasters> PurchaseMasters { get; set; }
        public DbSet<SalesMaster> SalesMaster { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<StockMaster> StockMaster { get; set; }
        public DbSet<SupplierAddress> SupplierAddress { get; set; }
        public DbSet<Unit> unit {  get; set; }
        public DbSet<VoucherType> VoucherType { get; set; }
        public DbSet<VoucherTypewithCom> voucherTypewithCom{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NG6QAOO;Initial Catalog=dbInventoryPos; TrustServerCertificate=true;Trusted_connection=true; ");
        }
    }
}
