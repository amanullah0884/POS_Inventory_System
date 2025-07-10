using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class SupplierAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AddressName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string PostCode { get; set; } = string.Empty;

        public string? ContactPerson { get; set; }

        public string? ContactPersonDesignation { get; set; }

        public string? Phone { get; set; }

        [ForeignKey("Thana")]
        public int ThanaID { get; set; }

        public virtual Thana? Thana { get; set; }
    }

    public class Supplier : BaseCLass
    {
        [Required]
        public string SupplierCode { get; set; } = string.Empty;

        [Required]
        public string SupplierName { get; set; } = string.Empty;

        [ForeignKey("CompanyInfo")]
        public int ComId { get; set; }

        public virtual CompanyInfo? Company{ get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public virtual CompanyBranch? Branch { get; set; }

        public string? SupplierBrand { get; set; }

        public string? AccountCode { get; set; }

        public string? ContactPerson { get; set; }

        public string? ContactPersonDesignation { get; set; }

        public string? Phone { get; set; }

        public string? Fax { get; set; }

        public string? Email { get; set; }

        public string? Website { get; set; }

        public new bool IsActive { get; set; }


        public bool IsArchive { get; set; }

        public string? NationalId { get; set; }

        public string? SupplierType { get; set; }
    }
}
