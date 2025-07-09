using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{

    public class Category : BaseCLass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? ShortCode { get; set; }

        public int ParentId { get; set; }

        public string? Description { get; set; }

        [NotMapped]
        public string? ParentCategory { get; set; }

        [NotMapped]
        public string? CompanyName { get; set; }

        [NotMapped]
        public string? BranchNAme { get; set; }
    }

    public class CategorywithCompany : BaseCLass
    {
        [ForeignKey("Category")]
        public int CatId { get; set; }

        [ForeignKey("CompanyInfo")]
        public int ComId { get; set; }

        [ForeignKey("CompanyBranch")]
        public int ComBranchId { get; set; }

        public virtual CompanyInfo? CompanyInfo { get; set; }
        public virtual Category? Category { get; set; }
        public virtual CompanyBranch? CompanyBranch { get; set; }
    }

    public class Product : BaseCLass
    {
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public int QuantityInStock { get; set; }
    }

    //public class Customer : BaseCLass
    //{
    //    [Required]
    //    [StringLength(100)]
    //    public string CustomerName { get; set; } = string.Empty;

    //    [StringLength(15)]
    //    public string? Phone { get; set; }

    //    [StringLength(100)]
    //    public string? Email { get; set; }
    //}

    public class User : BaseCLass
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Role { get; set; } = string.Empty;
    }

    public class Invoice : BaseCLass
    {
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal TotalAmount { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }

    public class InvoiceItem : BaseCLass
    {
        public int InvoiceId { get; set; }

        [ForeignKey("InvoiceId")]
        public virtual Invoice? Invoice { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Subtotal => Quantity * UnitPrice;
    }

    //public class Brand : BaseCLass
    //{
    //    public int Id { get; set; }

    //    [Required]
    //    public string Name { get; set; } = string.Empty;

    //    public string? Description { get; set; }
    //}

    //public class BrandwithCom : BaseCLass
    //{
    //    [ForeignKey("Brand")]
    //    public int BrandId { get; set; }

    //    [ForeignKey("CompanyInfo")]
    //    public int ComId { get; set; }

    //    [ForeignKey("CompanyBranch")]
    //    public int BranchId { get; set; }

    //    public virtual Brand? Brand { get; set; }
    //    public virtual CompanyInfo? CompanyInfo { get; set; }
    //    public virtual CompanyBranch? CompanyBranch { get; set; }
    //}

    //public class CompanyInfo : BaseCLass
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; } = string.Empty;
    //    public string? Address { get; set; }
    //    public string? Phone { get; set; }
    //}

    //public class CompanyBranch : BaseCLass
    //{
    //    public int Id { get; set; }
    //    public string BranchName { get; set; } = string.Empty;
    //    public string? Location { get; set; }
    //    public int CompanyINfoId { get; set; }

    //    [ForeignKey("CompanyINfoId")]
    //    public virtual CompanyInfo? CompanyInfo { get; set; }
    //}

}
