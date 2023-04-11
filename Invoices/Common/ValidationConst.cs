namespace Invoices.Common
{
    public class ValidationConst
    {
        // Product
        public const int ProductNameMinLength = 9;
        public const int ProductNameMaxLength = 30;

        public const decimal PriceMinRange = 5m;
        public const decimal PriceMaxRange = 1000m;

        //public const int CategoryTypeMinLength = 0;
        //public const int CategoryTypeMaxLength = 4;

        // Address
        public const int StreetNameMinLength = 10;
        public const int StreetNameMaxLength = 20;

        public const int CityNameMinLength = 5;
        public const int CityNameMaxLength = 15;

        public const int CountryNameMinLength = 5;
        public const int CountryNameMaxLength = 15;

        // Invoice
        public const int InvoiceNumberMinRange = 1000000000;
        public const int InvoiceNumberMaxRange = 1500000000;

        //public const int InvoiceCurrencyTypeMinLength = 1;
        //public const int InvoiceCurrencyTypeMaxLength = 3;

        // Client
        public const int ClientNameMinLength = 10;
        public const int ClientNameMaxLength = 25;

        public const int ClientNumberVatMinLength = 10;
        public const int ClientNumberVatMaxLength = 15;
    }
}
