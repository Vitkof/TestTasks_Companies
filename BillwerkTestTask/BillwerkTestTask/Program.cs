using System;
using System.Collections.Generic;

namespace BillwerkTestTask
{
    class Program
    {
        static void Main()
        {
            var fitness = new Subscription 
            { 
                Start = new DateTime(2017, 03, 03), 
                End = null, 
                PricePerPeriod = 10.00m 
            };


            var discounts = new List<Discount>{
                new Discount { 
                    Start = new DateTime(2017, 03, 04), 
                    End = new DateTime(2017, 03, 17), 
                    PercentReduction = 50},
                new Discount { 
                    Start = new DateTime(2017, 03, 10, 12, 0, 0), 
                    End = new DateTime(2017, 04, 10, 12, 0, 0), 
                    PercentReduction = 20},
                new Discount {
                    Start = new DateTime(2017, 03, 11, 12, 0, 0),
                    End = new DateTime(2017, 03, 13, 12, 0, 0),
                    PercentReduction = 70},
                new Discount {
                    Start = new DateTime(2017, 04, 11, 12, 0, 0),
                    End = new DateTime(2017, 04, 13, 12, 0, 0),
                    PercentReduction = 80},
            };

            var billingEnd = new DateTime(2017, 05, 03);

            var invoiceLines = BillingHelper.BillSubscriptionWithDiscounts(fitness, discounts, billingEnd);

            foreach (var line in invoiceLines)
                Console.WriteLine(line);
        }
    }
}
