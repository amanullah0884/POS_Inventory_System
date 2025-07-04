using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class VoucherType : BaseCLass
    {
        [Required]
        public string VoucherName { get; set; } = string.Empty;

        [Required]
        public string PrefixCode { get; set; } = string.Empty;

        public string? VoucherNameB { get; set; }
    }

    public class VoucherTypewithCom : BaseCLass
    {
        [ForeignKey("VoucherType")]
        public int VoucherTypeId { get; set; }

        [ForeignKey("CompanyINfo")]
        public int CompanyId { get; set; }

        [ForeignKey("Branch")]
        public int BranchID { get; set; }

        public virtual CompanyINfo CompanyINfo { get; set; } = null!;

        public virtual CompanyBranch Branch { get; set; } = null!;

        public virtual VoucherType VoucherType { get; set; } = null!;
    }
}
