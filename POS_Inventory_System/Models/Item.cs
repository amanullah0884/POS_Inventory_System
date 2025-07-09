using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class Item : BaseCLass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(5)]
        public string Code { get; set; } = string.Empty; // Barcode

        public string Sku { get; set; } = string.Empty;
        // Stock keeping unit, example: ABC-12345-S-BL

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [ForeignKey("Category")]
        public int ItemCategoryId { get; set; }

        public decimal PurchasePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal WholeSalePrice { get; set; }
        public decimal ProfitAmountInPercentage { get; set; }
        public decimal ProfitAmount { get; set; }
        public decimal AveragePurchasePrice { get; set; }
        public decimal LastPurchasePrice { get; set; }
        public decimal IdealPrice { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        [ForeignKey("Model")]
        public int ModelId { get; set; }

        [ForeignKey("Unit")]
        public int? UnitId { get; set; }

        public decimal ReorderLevel { get; set; }
        public decimal MaxDiscount { get; set; }
        public decimal VatRate { get; set; }
        public decimal VatAmount { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal DiscountAmount { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual Model? Model { get; set; }
        public virtual Unit? Unit { get; set; }
    }

    public class ItemSalesPrice : BaseCLass
    {
        [Required]
        [ForeignKey("Item")]
        public int ItemId { get; set; }

        [Required]
        public decimal OtherCostPrice { get; set; }

        [Required]
        public decimal PurchasePrice { get; set; }

        [Required]
        public decimal SalesPrice { get; set; }

        [Required]
        public decimal SalesPriceRate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly EffectiveFrom { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? EffectiveTo { get; set; }

        [NotMapped]
        public string? ItemName { get; set; }

        [NotMapped]
        public string? ItemCode { get; set; }

        [ForeignKey("CompanyInfo")]
        public int ComId { get; set; }

        [ForeignKey("CompanyBranch")]
        public int BranchId { get; set; }

        public virtual Item? Item { get; set; }
        public virtual CompanyInfo? CompanyInfo { get; set; }
        public virtual CompanyBranch? CompanyBranch { get; set; }
    }

    public class ItemwithCom : BaseCLass
    {
        [ForeignKey("Item")]
        public int ItemId { get; set; }

        [ForeignKey("CompanyInfo")]
        public int ComId { get; set; }

        [ForeignKey("CompanyBranch")]
        public int BranchId { get; set; }

        public virtual CompanyInfo? CompanyInfo { get; set; }
        public virtual CompanyBranch? CompanyBranch { get; set; }
        public virtual Item? Item { get; set; }
    }
}
