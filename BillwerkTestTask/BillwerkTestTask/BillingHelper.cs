using System;
using System.Collections.Generic;

namespace BillwerkTestTask
{
    static class BillingHelper
    {
        internal static IEnumerable<InvoiceLine> BillSubscriptionWithDiscounts(Subscription subscription, List<Discount> discounts, DateTime billingEnd)
        {
            var result = new List<InvoiceLine>();

            var sortedDiscounts = new SortedList<DateTime, Discount>();

            foreach(var discount in discounts)
            {
                sortedDiscounts.Add(discount.Start, discount);
            }


            DateTime startPrev = subscription.Start;
            DateTime endPrev = billingEnd;
            decimal percentsPrev = 0m;


            while(sortedDiscounts.Count > 0)
            {
                var start = sortedDiscounts.Keys[0];
                var end = sortedDiscounts.Values[0].End;
                var percents = sortedDiscounts.Values[0].PercentReduction;

                if (start < endPrev)
                {
                    if (percentsPrev < percents)  // starts greater discount
                    {
                        
                        if (percentsPrev != 0m)
                        {
                            if (end < endPrev)  
                            {
                                var notEndedDiscount = new Discount
                                {
                                    Start = end,
                                    End = endPrev,
                                    PercentReduction = percentsPrev
                                };

                                sortedDiscounts.Add(end, notEndedDiscount);
                            }

                            sortedDiscounts.Remove(startPrev);
                        }

                        if(startPrev != start)
                        {
                            var line = GetDiscountLine(subscription, startPrev, start, percentsPrev);
                            result.Add(line);
                        }

                        
                        percentsPrev = percents;
                        startPrev = start;
                        endPrev = end;
                    }
                    else if(percentsPrev == percents)
                    {
                        if(sortedDiscounts.Count == 1)
                        {
                            var line = GetDiscountLine(subscription, start, end, percentsPrev);
                            result.Add(line);
                            sortedDiscounts.Remove(start);
                        }
                        else
                        {
                            sortedDiscounts.Remove(start);
                        }
                    }
                    else
                    {
                        if(endPrev < end)
                        {
                            var notStartedDiscount = sortedDiscounts.Values[0];
                            notStartedDiscount.Start = endPrev;
                            sortedDiscounts.Add(endPrev, notStartedDiscount);
                        }

                        sortedDiscounts.Remove(start);
                    }

                }
                else  // there is no bigger discount in this period of time
                {
                    var line = GetDiscountLine(subscription, startPrev, endPrev, percentsPrev);
                    result.Add(line);
                    sortedDiscounts.Remove(startPrev);

                    if(start == endPrev)
                    {
                        startPrev = start;
                        endPrev = end;
                        percentsPrev = percents;
                    }
                    else
                    {
                        startPrev = endPrev;
                        endPrev = billingEnd;
                        percentsPrev = 0m;
                    }

                }
            }

            if(endPrev < billingEnd)
            {
                var line = GetSimpleLine(subscription, endPrev, billingEnd);
                result.Add(line);
            }

            return result;
        }

        private static InvoiceLine GetDiscountLine(Subscription sub, DateTime start, DateTime end, decimal percents)
        {
            var duration = Convert.ToDecimal((end - start).TotalDays);
            var price = sub.PricePerPeriod * (1 - percents / 100);

            return new InvoiceLine
            {
                Start = start,
                End = end,
                PricePerPeriod = price,
                Duration = duration,
                Total = duration * price
            };
        }

        private static InvoiceLine GetSimpleLine(Subscription sub, DateTime start, DateTime end)
        {
            return GetDiscountLine(sub, start, end, 0m);
        }

        internal static InvoiceLine BillSubscription(Subscription subscription, DateTime billingEnd)
        {
            var duration = Convert.ToDecimal((billingEnd - subscription.Start).TotalDays);
            var price = subscription.PricePerPeriod;

            var line = new InvoiceLine()
            {
                Start = subscription.Start,
                End = billingEnd,
                PricePerPeriod = price,
                Duration = duration,
                Total = duration * price
            };

            return line;
        }
    }
}
