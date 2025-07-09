using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory_System.Models
{
    public class Country : BaseCLass
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ShortName { get; set; } = string.Empty;

        [Required]
        public string Code { get; set; } = string.Empty;

        [ForeignKey("Currency")]
        public int CurrencyID { get; set; }

        public new bool IsActive { get; set; }

        public virtual Currency? Currency { get; set; }
    }

    public class Currency
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ShortName { get; set; } = string.Empty;

        public string? SymbolPath { get; set; }
    }


    public class Division
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ShortName { get; set; } = string.Empty;

        [Required]
        public string Code { get; set; } = string.Empty;

        public new bool IsActive { get; set; }

        [ForeignKey("Country")]
        public int CountryID { get; set; }

        public virtual Country? Country { get; set; }
    }

    public class District
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ShortName { get; set; } = string.Empty;

        [Required]
        public string Code { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        [ForeignKey("Division")]
        public int DivisionID { get; set; }

        public virtual Division? Division { get; set; }
    }

    public class Thana
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ShortName { get; set; } = string.Empty;

        [Required]
        public string Code { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        [ForeignKey("District")]
        public int DistrictID { get; set; }

        public virtual District? District { get; set; }
    }
}

