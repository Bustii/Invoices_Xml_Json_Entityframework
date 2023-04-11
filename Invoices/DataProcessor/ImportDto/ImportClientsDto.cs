using Invoices.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ImportClientsDto
    {
        [Required]
        [XmlElement("Name")]
        [MaxLength(ValidationConst.ClientNameMaxLength)]
        [MinLength(ValidationConst.ClientNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("NumberVat")]
        [MaxLength(ValidationConst.ClientNumberVatMaxLength)]
        [MinLength(ValidationConst.ClientNumberVatMinLength)]
        public string NumberVat { get; set; } = null!;

        [XmlArray("Addresses")] 
        public ImportAddressesDto[] Addresses { get; set; } = null!;
    }
}
