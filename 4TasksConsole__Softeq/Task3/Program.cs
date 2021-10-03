using System;
using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter 3 numbers: ");
            Calculate(Console.ReadLine());
        }


        private static void Calculate(string input)
        {
            int a, b, c;
            try
            {
                var reg = new Regex(" +");
                string[] arr = reg.Split(input.Trim());

                a = Convert.ToInt32(arr[0]);
                b = Convert.ToInt32(arr[1]);
                c = Convert.ToInt32(arr[2]);

                long max = 0;
                for (int x = 0; x <= c / a; x++)
                {
                    for (int y = 0; y <= c / b; y++)
                    {
                        if (a * x + b * y == c)
                        {
                            var result = Math.Pow(a, x) * Math.Pow(b, y);
                            if (result > max) max = (long)result;
                        }
                    }
                }
                Console.WriteLine(max);
            }
            catch (FormatException)
            {
                Console.WriteLine("Input string isn't a sequence of digits.");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
