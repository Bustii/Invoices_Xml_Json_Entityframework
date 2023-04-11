using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Invoices.Common;

namespace Invoices.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConst.StreetNameMaxLength)]
        public string StreetName { get; set; } = null!;

        [Required]
        public int StreetNumber { get; set; }

        [Required] 
        public string PostCode { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConst.CityNameMaxLength)]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConst.CountryNameMaxLength)]
        public string Country { get; set; } = null!;

        [Required]
        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; } = null!;
    }
}
