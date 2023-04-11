using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Invoices.Common;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Address")]
    public class ImportAddressesDto
    {
        [Required]
        [XmlElement("StreetName")]
        [MaxLength(ValidationConst.StreetNameMaxLength)]
        [MinLength(ValidationConst.StreetNameMinLength)]
        public string StreetName { get; set; } = null!;

        [Required]
        [XmlElement("StreetNumber")] 
        public int StreetNumber { get; set; }

        [Required]
        [XmlElement("PostCode")]
        public string PostCode { get; set; } = null!;

        [Required]
        [XmlElement("City")]
        [MaxLength(ValidationConst.CityNameMaxLength)]
        [MinLength(ValidationConst.CityNameMinLength)]
        public string City { get; set; } = null!;

        [Required]
        [XmlElement("Country")]
        [MaxLength(ValidationConst.CountryNameMaxLength)]
        [MinLength(ValidationConst.CountryNameMinLength)]
        public string Country { get; set; } = null!;
    }
}
