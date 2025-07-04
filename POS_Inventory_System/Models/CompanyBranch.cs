using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class CompanyBranch : BaseCLass
    {
        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string TIN { get; set; } = string.Empty;

        [Required]
        public string VatRegistryNo { get; set; } = string.Empty;

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

        [ForeignKey("CompanyInfo")]
        public int ComId { get; set; }

        public virtual CompanyInfo? CompanyInfo { get; set; }
    }
}
