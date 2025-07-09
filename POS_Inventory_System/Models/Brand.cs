using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{

    public class Brand : BaseCLass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }

    public class BrandwithCom : BaseCLass
    {
        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        [ForeignKey("CompanyInfo")]
        public int ComId { get; set; }

        [ForeignKey("CompanyBranch")]
        public int BranchId { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual CompanyInfo? CompanyInfo { get; set; }
        public virtual CompanyBranch? CompanyBranch { get; set; }
    }

    //public class CompanyInfo : BaseCLass
    //{
    //    public int Id { get; set; }

    //    public string Name { get; set; }

    //    public string? Address { get; set; }

    //    public string? Phone { get; set; }
    //}

    //public class CompanyBranch : BaseCLass
    //{
    //    public int Id { get; set; }

    //    public string BranchName { get; set; }

    //    public string? Location { get; set; }

    //    public int CompanyINfoId { get; set; }

    //    [ForeignKey("CompanyINfoId")]
    //    public virtual CompanyInfo CompanyInfo { get; set; }


}
