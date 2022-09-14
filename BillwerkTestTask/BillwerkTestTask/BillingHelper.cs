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
                try
                {
                    sortedDiscounts.Add(discount.Start, discount);
                }
                catch
                {
                    var value = sortedDiscounts[discount.Start];
                    if(value.PercentReduction < discount.PercentReduction)
                    {
                        sortedDiscounts.Remove(value.Start);
                        value.Start = discount.End;
                        sortedDiscounts.Add(value.Start, value);
                    }
                    else
                    {
                        discount.Start = value.End;
                    }
                    sortedDiscounts.Add(discount.Start, discount);
                }
            }

            DateTime time = subscription.Start;
            Discount previous = null;

            void AddLine()
            {
                var line = GetDiscountLine(subscription, previous);
                if (line.Duration > 0)
                    result.Add(line);
            }

            void Pop()
            {
                AddLine();
                time = previous.End;
                previous = sortedDiscounts.Values[0];
                sortedDiscounts.RemoveAt(0);
            }


            while(sortedDiscounts.Count > 0)
            {
                Discount current = sortedDiscounts.Values[0];

                if (previous == null)
                {
                    previous = new Discount
                    {
                        Start = time,
                        End = current.Start
                    };

                    Pop();
                }
                else if (current.Start < previous.End)
                {
                    if (previous.PercentReduction < current.PercentReduction)  // greater discount
                    {
                        if (current.End < previous.End)
                        {
                            var notEndedDiscount = new Discount
                            {
                                Start = current.End,
                                End = previous.End,
                                PercentReduction = previous.PercentReduction
                            };

                            sortedDiscounts.Add(current.End, notEndedDiscount);
                        }

                        previous.End = current.Start;
                        Pop();
                    }
                    else  // smaller or equal discount
                    {
                        if (previous.End < current.End)
                        {
                            current.Start = previous.End;
                            sortedDiscounts.Add(previous.End, current);
                        }
                        sortedDiscounts.RemoveAt(0);
                    }
                }
                else if (current.Start == previous.End) // no discount in this period of time
                {
                    Pop();
                }
                else
                {
                    AddLine();
                    time = previous.End;
                    previous = null;
                }
            }

            if (previous != null)
            {
                AddLine();
            }
            else
            {
                result.Add(BillSubscription(subscription, billingEnd));
                return result;
            }


            if (previous.End < billingEnd)
            {
                previous = new Discount
                {
                    Start = previous.End,
                    End = billingEnd
                };
                AddLine();
            }

            return result;
        }

        private static InvoiceLine GetDiscountLine(Subscription sub, Discount discount) 
        {
            var start = discount.Start;
            var end = discount.End;
            var percents = discount.PercentReduction;

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