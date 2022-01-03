using ConsoleApp1.Models;
using ConsoleApp1.Services;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //not:company adress service ve taxnumberlookupservice farklı şekillerde sorgulama yapabilme kabiliyetine sahip olsunlar diyye company constructor içerisindeki interfa-selar üzerinden bağlantı kuruldu bu sayede company constructor içerisine gönderilen  classlar ile adapte bir şekilde çalışması sağlandı.polimorphism interfase vasıtası ile uyguland ı.
            //contructor
            //var company = new Company(
            //    name: "NBUY LTD ŞTİ",
            //    address: "1, Saip Molla Caddesi, Kısayol Sk., 34800 Beykoz / İstanbul",
            //    taxNumber: "312314132",
            //    companyAddressService: new NBuyCompanyAddressService(),//encapsulation
            //    taxNumberLookupService: new NbuyTaxNumberLookupService()
            //    );
            //company.SetPhoneNumber("0(212) 346 1010");

            //company.Name = "aaaaaaaaa";
            //company.TaxNumber = "1234321";
            var company1 = new Company(
               name: "NBUY LTD ŞTİ",
               address: "Göztepe, Kavacık Kavşağı, 34810 Beykoz/İstanbul",
               taxNumber: "431242541",
               companyAddressService: new NBuyCompanyAddressService(),//encapsulation
               taxNumberLookupService: new NbuyTaxNumberLookupService()
               ); 
            company1.SetPhoneNumber("0(212) 346 1010");
            var company2 = new Company(
               name: "NBUY LTD ŞTİ",
               address: "Acarlar Mahallesi Acarkent Sitesi Acarblu Rezidans Ticaret Merkezi 1-A, Acarkent B1 Kapısı, 34800 Beykoz/İstanbul",
               taxNumber: "2314524322",
               companyAddressService: new NBuyCompanyAddressService(),//encapsulation
               taxNumberLookupService: new NbuyTaxNumberLookupService()
               );
            company2.SetPhoneNumber("0(212) 346 1010");
            var invoice = new Invoice(exporter:company1,consignee:company2);//items.add yapılamasın diye readonly ekledik
            invoice.AddInvoiceItem(
                new InvoiceItem(
                    description: "Tasarım Bedeli",
                    unitPrice: 1000,
                    unitType: InvoiceUnitType.Daily,
                    amount: 5));
            invoice.AddInvoiceItem(
                new InvoiceItem(
                    description: "Tasarım Bedeli",
                    unitPrice: 300,
                    unitType: InvoiceUnitType.Hourly,
                    amount: 8));
            invoice.AddInvoiceItem(
               new InvoiceItem(
                   description: "Tasarım Bedeli",
                   unitPrice: 5000,
                   unitType: InvoiceUnitType.Monthly,
                   amount: 1));


            Console.WriteLine("Hello World!");
        }
    }
}
