using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class Customer : BaseCLass
    {
        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [ForeignKey("Company")]
        public int ComId { get; set; }

        public virtual CompanyInfo? Company { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public virtual CompanyBranch? Branch { get; set; }

        [Required]
        public string CustomerType { get; set; } = string.Empty;

        public string? AccountCode { get; set; }

        [Required]
        public string ContactPerson { get; set; } = string.Empty;

        [Required]
        public string ContactPersonDesignation { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        public string? Fax { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? Website { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public bool IsArchive { get; set; }

        public string? NationalId { get; set; }
    }
}
