using System;
using System.Collections.Generic;

namespace ReceiptTrackerLibrary
{
    public class Receipt
    {
        public decimal TotalSalesTaxGbp { get; set; }
        public decimal TotalGbp { get; set; }
        public List<ReceiptItemWithSalesTax> ReceiptItems { get; set; }

        public Receipt()
        {
            ReceiptItems = new List<ReceiptItemWithSalesTax>();
        }

        public override string ToString()
        {
            var lines = new List<string>();

            foreach (var item in ReceiptItems)
            {
                lines.Add($"{item.Quantity} {item.Item}: £{(item.PriceGbp + item.SalesTaxGbp):N2}");
            }
            
            lines.Add($"Sales Taxes: £{TotalSalesTaxGbp:N2}");
            lines.Add($"Total: £{TotalGbp:N2}");
            return String.Join(Environment.NewLine, lines);
        }
    }

    public class ReceiptItem
    {
        public string Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceGbp { get; set; }
        public ItemType? ItemType { get; set; }
        public bool Imported { get; set; }
    }

    public class ReceiptItemWithSalesTax : ReceiptItem
    {
        public decimal SalesTaxGbp { get; set; }
    }

    public enum ItemType
    {
        Book,
        Food,
        Medical
    }
}