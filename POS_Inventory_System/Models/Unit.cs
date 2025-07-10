using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public partial class Unit : BaseCLass
    {
        //[Key]
        //public int Id { get; set; }

        [Required]
        public string ActualName { get; set; } = string.Empty;

        public string? ShortName { get; set; }

        public int? BaseUnitId { get; set; }  // e.g. 1 kg = 1000 gram, 1kg is BaseUnit

        public decimal? BaseUnitMultiplier { get; set; }  // e.g. 1000 gram
    }

    public class CompanyUnit : BaseCLass
    {
        [ForeignKey("Unit")]
        public int UnitId { get; set; }

        [ForeignKey("CompanyInfo")]
        public int ComId { get; set; }

        [ForeignKey("CompanyBranch")]
        public int BranchId { get; set; }

        public virtual CompanyInfo CompanyInfo { get; set; } = null!;

        public virtual CompanyBranch CompanyBranch { get; set; } = null!;

        public virtual Unit Unit { get; set; } = null!;
    }
}
