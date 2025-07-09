using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class CompanyInfo : BaseCLass
    {
        [Key]
        public int CompanyID { get; set; }
        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string TIN { get; set; } = string.Empty;

        [Required]
        public string VatRegistryNo { get; set; } = string.Empty;

        [Required]
        public string FiscalYearStartDate { get; set; } = string.Empty;

        public bool IsSystemOwner { get; set; }

        [Required]
        public string ContactPerson { get; set; } = string.Empty;

        [Required]
        public string ContactPersonDesignation { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        public string? Fax { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        public string? Website { get; set; }

        public new bool IsActive { get; set; }

        public bool IsHeadOffice { get; set; }
    }

    public class ComAddress
    {
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

        [ForeignKey("CompanyBranch")]
        public int CompanyBranchId { get; set; }

        public virtual CompanyBranch? CompanyBranch { get; set; }

        [ForeignKey("Thana")]
        public int ThanaID { get; set; }

        public virtual Thana? Thana { get; set; }
    }

    //public class CompanyBranch : BaseCLass
    //{
    //    [Required]
    //    public string Code { get; set; } = string.Empty;

    //    [Required]
    //    public string Name { get; set; } = string.Empty;

    //    [Required]
    //    public string TIN { get; set; } = string.Empty;

    //    [Required]
    //    public string VatRegistryNo { get; set; } = string.Empty;

    //    [Required]
    //    public string ContactPerson { get; set; } = string.Empty;

    //    [Required]
    //    public string ContactPersonDesignation { get; set; } = string.Empty;

    //    [Required]
    //    public string Phone { get; set; } = string.Empty;

    //    public string? Fax { get; set; }

    //    [Required]
    //    public string Email { get; set; } = string.Empty;

    //    public string? Website { get; set; }

    //    [Required]
    //    public bool IsActive { get; set; }

    //    [ForeignKey("CompanyInfo")]
    //    public int ComId { get; set; }

    //    public virtual CompanyInfo? CompanyInfo { get; set; }
    //}
}
