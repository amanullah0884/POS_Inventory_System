using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class Model : BaseCLass
    {
    //    [Key]
    //    public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
    }

    public class ModelWithCom : BaseCLass
    {
        //[ForeignKey("Model")]
        //public int ModelId { get; set; }

        [ForeignKey("CompanyInfo")]
        public int ComId { get; set; }

        [ForeignKey("CompanyBranch")]
        public int BranchId { get; set; }

        public CompanyInfo CompanyInfo { get; set; } = null!;
        public CompanyBranch CompanyBranch { get; set; } = null!;
        public Model Model { get; set; } = null!;
    }
}
