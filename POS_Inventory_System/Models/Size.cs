using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class Size : BaseCLass
    {
        //[Key]
        //public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }

    public class SizewithCom : BaseCLass
    {
        [ForeignKey("Size")]
        public int SizeId { get; set; }

        [ForeignKey("CompanyInfo")]
        public int ComId { get; set; }

        [ForeignKey("CompanyBranch")]
        public int BranchId { get; set; }

        public virtual CompanyInfo? CompanyInfo { get; set; }

        public virtual CompanyBranch? CompanyBranch { get; set; }

        public virtual Size? Size { get; set; }
    }
}
