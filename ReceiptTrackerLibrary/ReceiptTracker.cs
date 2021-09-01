using System;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace ReceiptTrackerLibrary
{
    public static class ReceiptTracker
    {
        public static Receipt Process(string fileName, decimal salesTaxRoundTo = (decimal)0.05)
        {
            var receipt = new Receipt();
            using var reader = new StreamReader(fileName);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<ReceiptItem>();

            foreach (var record in records)
            {
                var subTotal = record.PriceGbp;
                decimal salesTax = 0;
                decimal importTax = 0;

                switch (record.ItemType)
                {
                    case ItemType.Book:
                    case ItemType.Food:
                    case ItemType.Medical:
                        // No sales tax applies
                        break;
                    
                    default:
                        salesTax = subTotal * (decimal)0.1;
                        break;
                }

                if (record.Imported)
                {
                    importTax = subTotal * (decimal)0.05;
                    salesTax += importTax;
                }

                salesTax = Math.Ceiling(salesTax / salesTaxRoundTo) * salesTaxRoundTo;
                subTotal += salesTax;
                receipt.ReceiptItems.Add(new ReceiptItemWithSalesTax
                {
                    Item = record.Item,
                    Quantity = record.Quantity,
                    PriceGbp = record.PriceGbp,
                    ItemType = record.ItemType,
                    Imported = record.Imported,
                    SalesTaxGbp = salesTax
                });
                receipt.TotalSalesTaxGbp += salesTax;
                receipt.TotalGbp += subTotal;
            }
            
            return receipt;
        }
    }
}