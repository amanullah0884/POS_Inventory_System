using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public enum FinanceType
    {
        Bank = 1,
        Cash,
        Mobile
    }

    public class PaymentMethod : BaseCLass
    {
        [Required]
        public string Name { get; set; } = string.Empty; // Cash, Bank, Bkash, Rocket, Nogod, Card

        [Required]
        public FinanceType FinanceTypeName { get; set; }
    }

    public class PaymentMethodDetails
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }

        public int? BankId { get; set; } // Bank details (nullable)

        [Required]
        public string AccountNumber { get; set; } = string.Empty; // Mobile/Bank account number

        [ForeignKey("CompanyInfo")]
        public int CompanyId { get; set; }

        [ForeignKey("Branch")]
        public int BranchID { get; set; }

        public virtual CompanyInfo? CompanyInfo { get; set; }
        public virtual CompanyBranch? Branch { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
    }
}
