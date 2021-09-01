using System;
using System.IO;
using Xunit;

namespace ReceiptTrackerTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var expected = @"1 book: £12.49
1 music CD: £16.49
1 chocolate bar: £0.85
Sales Taxes: £1.50
Total: £29.83";
            var actual = ReceiptTrackerLibrary.ReceiptTracker.Process(Path.Combine("files", "scenario1.csv")).ToString();
            Assert.Equal(expected, actual, true, true, true);
        }
        
        [Fact]
        public void Test2()
        {
            var expected = @"1 imported box of chocolates: £10.50
1 imported bottle of perfume: £54.65
Sales Taxes: £7.65
Total: £65.15";
            var actual = ReceiptTrackerLibrary.ReceiptTracker.Process(Path.Combine("files", "scenario2.csv")).ToString();
            Assert.Equal(expected, actual, true, true, true);
        }
        
        [Fact]
        public void Test3()
        {
            var expected = @"1 imported bottle of perfume: £32.19
1 bottle of perfume: £20.89
1 packet of headache pills: £9.75
1 imported box of chocolates: £11.85
Sales Taxes: £6.70
Total: £74.68";
            var actual = ReceiptTrackerLibrary.ReceiptTracker.Process(Path.Combine("files", "scenario3.csv")).ToString();
            Assert.Equal(expected, actual, true, true, true);
        }
    }
}