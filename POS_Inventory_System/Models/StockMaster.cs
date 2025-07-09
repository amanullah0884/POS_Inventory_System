using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class StockMaster : BaseCLass
    {
        [ForeignKey("Item")]
        public int ItemId { get; set; } // assuming string id

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string? Unit { get; set; }

        public double OpeningQty { get; set; }

        public double QuantityInStock { get; set; } // Current quantity in stock

        public double ReorderLevel { get; set; } // Minimum stock before reordering

        public double PurchasePrice { get; set; }  // Cost Price

        public double SellingPrice { get; set; } // Retail Price

        [ForeignKey("CompanyInfo")]
        public int CompanyId { get; set; }

        [ForeignKey("Branch")]
        public int BranchID { get; set; }

        public virtual CompanyInfo? CompanyInfo { get; set; }

        public virtual CompanyBranch? Branch { get; set; }

        public virtual Item? Item { get; set; }

        public virtual Category? Category { get; set; }
    }

    public class StockDetails : BaseCLass
    {
        [ForeignKey("StockMaster")]
        public int StockID { get; set; }

        public DateTime TransactionDate { get; set; }

        [Required]
        public string TransactionType { get; set; } = string.Empty;  // "IN", "OUT", "RETURN", "ADJUST"

        public double Quantity { get; set; }

        public double UnitPrice { get; set; }

        [NotMapped]
        public double TotalAmount => Quantity * UnitPrice;

        public string? ReferenceNo { get; set; }  // ex., Invoice or Voucher number

        public string? Remarks { get; set; }

        [ForeignKey("CompanyInfo")]
        public int CompanyId { get; set; }

        [ForeignKey("Branch")]
        public int BranchID { get; set; }

        public virtual CompanyInfo? CompanyInfo { get; set; }

        public virtual CompanyBranch? Branch { get; set; }

        public virtual StockMaster? StockMaster { get; set; }
    }
}
