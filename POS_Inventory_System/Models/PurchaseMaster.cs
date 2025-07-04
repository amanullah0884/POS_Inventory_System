using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class PurchaseMasters : BaseCLass
    {
        [DataType(DataType.Date)]
        public DateOnly PurchaseDate { get; set; }

        public double TotalQuantity { get; set; }

        public double TotalPrice { get; set; }

        public double BonusAmount { get; set; }

        public double NetAmount { get; set; }

        [Required]
        public string VoucherNo { get; set; } = string.Empty;

        public int TranNo { get; set; }

        [Required]
        public string InvoiceNo { get; set; } = string.Empty;

        public double TDiscountrate { get; set; }

        public double TVatrate { get; set; }

        public double TDiscountamount { get; set; }

        public double TVatamount { get; set; }

        public double Paidamount { get; set; }

        public double Due { get; set; }

        public double Convence { get; set; }

        public double Packaging { get; set; }

        public string? Note { get; set; }

        public double LaborCost { get; set; }

        public double TotalCost { get; set; }

        public double UnitCost { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierID { get; set; }

        [ForeignKey("PaymentMethod")]
        public int PaymodeID { get; set; }

        [ForeignKey("VoucherType")]
        public int VoucherTypeID { get; set; }

        [ForeignKey("CompanyINfo")]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyBranch")]
        public int BranchID { get; set; }

        public virtual CompanyINfo? CompanyINfo { get; set; }

        public virtual CompanyBranch? Branch { get; set; }

        public virtual VoucherType? VoucherType { get; set; }

        public virtual PaymentMethod? PaymentMethod { get; set; }

        public virtual Supplier? Supplier { get; set; }
    }

    public class PurchaseDetails : BaseCLass
    {
        [Required]
        public string Code { get; set; } = string.Empty;

        public int MasterId { get; set; }

        public int Bonus { get; set; }

        public double Discountrate { get; set; }

        public double Vatrate { get; set; }

        public double Discountamount { get; set; }

        public double Vatamount { get; set; }

        public double NetAmount { get; set; }

        public double UnitQty { get; set; }

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }

        public int ProductId { get; set; }

        public int UnitId { get; set; }

        [ForeignKey("PurchaseMasters")]
        public int PurchasemasterID { get; set; }

        [ForeignKey("CompanyINfo")]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyBranch")]
        public int BranchID { get; set; }

        public virtual CompanyINfo? CompanyINfo { get; set; }

        public virtual CompanyBranch? Branch { get; set; }

        public virtual PurchaseMasters? PurchaseMasters { get; set; }
    }
}
