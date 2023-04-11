using Invoices.Common;
using Invoices.Data.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductDto
    {
        [Required]
        [MaxLength(ValidationConst.ProductNameMaxLength)]
        [MinLength(ValidationConst.ProductNameMinLength)]
        public string Name { get; set; } = null!;
        
        [Required]
        [Range((double)ValidationConst.PriceMinRange, (double)ValidationConst.PriceMaxRange)]
        public decimal Price { get; set; }

        [Required]
        [Range(0,4)]
        public CategoryType CategoryType { get; set; }

        public int[] Clients { get; set; } = null!;
    }
}
