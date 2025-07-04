using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class SalesMaster : BaseCLass
    {
        [DataType(DataType.Date)]
        public DateOnly SalesDate { get; set; }

        public double TotalQuantity { get; set; }

        public double TotalPrice { get; set; }

        // Assuming VoucherNo should be string, if numeric then int
        [Required]
        public string VoucherNo { get; set; } = string.Empty;

        [Required]
        public string BillNo { get; set; } = string.Empty;

        public double TDiscountrate { get; set; }

        public double TVatrate { get; set; }

        public double TDiscountamount { get; set; }

        public double TVatamount { get; set; }

        public double Paidamount { get; set; }

        public double Due { get; set; }

        public double Convence { get; set; }

        public double Packing { get; set; }

        public string? Note { get; set; }

        [ForeignKey("PaymentMethod")]
        public int PaymentModeId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

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

        public virtual Customer? Customer { get; set; }
    }
}
