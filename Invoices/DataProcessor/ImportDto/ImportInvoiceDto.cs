using System.ComponentModel.DataAnnotations;
using Invoices.Common;
using Invoices.Data.Models.Enums;
using Newtonsoft.Json;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportInvoiceDto
    {
       
        [Required]
        [Range(ValidationConst.InvoiceNumberMinRange, ValidationConst.InvoiceNumberMaxRange)]
        public int Number { get; set; }

        
        [Required] 
        public DateTime IssueDate { get; set; }

        
        [Required]
        public DateTime DueDate { get; set; }

       
        [Required]
        public decimal Amount { get; set; }

        [Required]
        [Range(0,2)]
        public CurrencyType CurrencyType { get; set; }

        
        [Required]
        public int ClientId { get; set; }
    }
}
