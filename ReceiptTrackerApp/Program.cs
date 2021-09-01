using System;
using System.IO;

namespace ReceiptTrackerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && File.Exists(args[0]))
            {
                Console.WriteLine(ReceiptTrackerLibrary.ReceiptTracker.Process(args[0]).ToString());
            }

            else
            {
                Console.WriteLine($"File not found: {args[0]}");
            }
        }
    }
}