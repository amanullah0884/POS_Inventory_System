using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class InventoryContext : DbContext
    {
        public InventoryContext()
        {

        }
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }
        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        public DbSet<CompanyBranch> CompanyBranch { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Item> Item { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbInventory; TrustServerCertificate=true;Trusted_connection=true; ");
        }
    }
}
