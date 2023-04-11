using Invoices.Data.Models;
using Invoices.DataProcessor.ExportDto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Invoices.DataProcessor
{
    using AutoMapper.QueryableExtensions;
    using AutoMapper;
    using Invoices.Data;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Trucks.Utilities;

    public class Serializer
    {
        private static XmlHelper xmlHelper;

        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InvoicesProfile>();
            });

            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportClientsDto[]), new XmlRootAttribute("Clients"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(sb);

            ExportClientsDto[] clientsDtos = context
                .Clients
                .Where(c => c.Invoices.Any(ci => ci.IssueDate >= date))
                .ProjectTo<ExportClientsDto>(config)
                .OrderByDescending(c => c.InvoicesCount)
                .ThenBy(c => c.Name)
                .ToArray();
            xmlSerializer.Serialize(sw, clientsDtos, namespaces);
            return sb.ToString().TrimEnd();
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {

            var products = context.Products
                .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .ToArray()
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .ToArray()
                        .Select(pc => new
                        {
                            Name = pc.Client.Name,
                            NumberVat = pc.Client.NumberVat
                        })
                        .OrderBy(n => n.Name)
                        .ToArray()
                })
                .OrderByDescending(t => t.Clients.Length)
                .ThenBy(n => n.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
    }
}