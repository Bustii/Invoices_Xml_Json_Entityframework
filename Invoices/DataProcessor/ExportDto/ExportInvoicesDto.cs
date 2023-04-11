using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Invoices.Common;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Invoice")]
    public class ExportInvoicesDto
    {
        [XmlElement("InvoiceNumber")]
        public int InvoiceNumber { get; set; }

        [XmlElement("InvoiceAmount")] 
        public decimal InvoiceAmount { get; set; }

        [XmlElement("DueDate")] 
        public string DueDate { get; set; } = null!;

        [XmlElement("Currency")]
        public string Currency { get; set; } = null!;
    }
}
