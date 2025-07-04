using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class Color : BaseCLass
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }

    public class ColorwithCom : BaseCLass
    {
        [ForeignKey("Color")]
        public int ColorId { get; set; }

        [ForeignKey("CompanyINfo")]
        public int ComId { get; set; }

        [ForeignKey("CompanyBranch")]
        public int BranchId { get; set; }

        public virtual CompanyINfo? CompanyINfo { get; set; }
        public virtual CompanyBranch? CompanyBranch { get; set; }
        public virtual Color? Color { get; set; }
    }
}
