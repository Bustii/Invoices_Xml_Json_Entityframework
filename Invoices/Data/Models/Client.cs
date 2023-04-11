using System.ComponentModel.DataAnnotations;
using Invoices.Common;

namespace Invoices.Data.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConst.ClientNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConst.ClientNumberVatMaxLength)]
        public string NumberVat { get; set; } = null!;

        public  ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
        public  ICollection<Address> Addresses { get; set; } = new HashSet<Address>();

        public  ICollection<ProductClient> ProductsClients { get; set; } = new HashSet<ProductClient>();
    }
}
