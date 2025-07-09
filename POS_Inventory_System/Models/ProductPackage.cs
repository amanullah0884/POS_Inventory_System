using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class ProductPackage : BaseCLass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        //public int NoofUser { get; set; }
        //public decimal SubscriptionFee { get; set; }
        //public int SubscriptionDuration { get; set; }
    }

    public class ProductPackagePrice : BaseCLass
    {
        [ForeignKey("ProductPackage")]
        public int ProductPackageId { get; set; }

        [Required]
        public int NoofUser { get; set; }

        [Required]
        public decimal SubscriptionFee { get; set; }

        [Required]
        public int SubscriptionDuration { get; set; } // Months

        public virtual ProductPackage? ProductPackage { get; set; }
    }

    public class Subscription : BaseCLass
    {
        [ForeignKey("CompanyInfo")]
        public int ComId { get; set; }

        [ForeignKey("CompanyBranch")]
        public int BranchId { get; set; }

        [ForeignKey("ProductPackage")]
        public int ProductPackageId { get; set; }

        [DataType(DataType.Date)]
        public DateTime SubscriptionDate { get; set; }

        [ForeignKey("ProductPackagePrice")]
        public int ProductPackagePriceId { get; set; }

        public int TrialDurationM { get; set; }

        public DateOnly? TrialEndDate { get; set; }

        public DateOnly? SubscriptionEndDate { get; set; }

        public virtual CompanyInfo? CompanyInfo { get; set; }
        public virtual CompanyBranch? CompanyBranch { get; set; }
        public virtual ProductPackage? ProductPackage { get; set; }
        public virtual ProductPackagePrice? ProductPackagePrice { get; set; }
    }

    public class SubscriptionRenew : BaseCLass
    {
        [ForeignKey("CompanyInfo")]
        public int ComId { get; set; }

        [ForeignKey("CompanyBranch")]
        public int BranchId { get; set; }

        [ForeignKey("ProductPackage")]
        public int ProductPackageId { get; set; }

        [DataType(DataType.Date)]
        public DateTime SubscriptionRenewDate { get; set; }

        [ForeignKey("ProductPackagePrice")]
        public int ProductPackagePriceId { get; set; }

        public DateOnly? SubscriptionEndDate { get; set; }

        public virtual CompanyInfo? CompanyInfo { get; set; }
        public virtual CompanyBranch? CompanyBranch { get; set; }
        public virtual ProductPackage? ProductPackage { get; set; }
        public virtual ProductPackagePrice? ProductPackagePrice { get; set; }

        // After renew, service will be automatically active
    }
}
