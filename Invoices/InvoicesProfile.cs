using System.Globalization;
using AutoMapper;
using Invoices.Data.Models;
using Invoices.DataProcessor.ExportDto;

namespace Invoices
{
    public class InvoicesProfile : Profile
    {
        public InvoicesProfile()
        {
            CreateMap<Invoice, ExportInvoicesDto>()
                .ForMember(dest => dest.InvoiceNumber, opt =>
                    opt.MapFrom(s => s.Number))
                .ForMember(dest => dest.InvoiceAmount, opt =>
                    opt.MapFrom(s => s.Amount))
                .ForMember(dest => dest.DueDate, opt =>
                    opt.MapFrom(s => s.DueDate.ToString("d", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Currency, opt =>
                    opt.MapFrom(s => s.CurrencyType.ToString()));
            CreateMap<Client, ExportClientsDto>()
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(s => s.Name))
                .ForMember(dest => dest.VatNumber, opt =>
                    opt.MapFrom(s => s.NumberVat))
                .ForMember(dest => dest.Invoices, opt =>
                    opt.MapFrom(s => s.Invoices
                        .ToArray()
                        .OrderBy(i => i.IssueDate)
                        .ThenByDescending(i => i.DueDate)));
        }
    }
}
