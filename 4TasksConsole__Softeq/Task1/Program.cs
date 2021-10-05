using System;

namespace Task1
{
    class Program
    {
        /// <summary>
        /// f(x) = A* x^4 + B* x^3 + C* x^2 + D* x + E
        /// 0 + E = 123.456
        private const double E = 123.456;
        ///  81* A + 27*B + 9* C + 3*D + 123.456 = 56.856
        /// 256* A - 64*B + 16*C - 4* D + 123.456 = -17.344
        /// 2401 A - 343 B + 49 C - 7 D + 123.456 = 1132.856
        /// 
        ///  81* A +  27* B +  9* C +  3* D = -66.6        |
        /// 256* A -  64* B +  16*C -  4* D = -140.8  (-1) | +
        /// 2401 A -  343 B +  49 C -  7* D = 1009.4       |
        /// -----------------------------------------------
        /// 2226 A -  252 B +  42 C         = 1083.6
        /// 
        /// 81* A  + 27* B  +  9* C +  3* D = -66.6   (-1) |
        /// 2401 A -  343 B +  49 C -  7* D = 1009.4       | +
        /// 10000A + 1000 B + 100 C + 10* D = 9200         |
        /// -----------------------------------------------
        /// 12320A +  630 B + 140 C         = 10276    (3) |
        /// 2226 A -  252 B +  42 C         =  1083.6 (-10)| +
        /// -----------------------------------------------
        /// 14700A + 4410 B                 = 19992
        /// 
        /// 
        ///  81* A +  27* B +  9* C +  3* D = -66.6   (4)  |
        /// 256* A -  64* B +  16*C -  4* D = -140.8  (3)  | +
        /// -----------------------------------------------
        /// 1092 A -  84* B +  84*C         = -688.8  (:84) |
        /// 2226 A -  252 B +  42 C         =  1083.6 (:-42)| +
        /// ------------------------------------------------
        ///  -40 A +    5 B                 =   -34   (-882)|
        /// 14700A + 4410 B                 = 19992         | +
        /// ------------------------------------------------
        /// 49980 A                         = 49980
        private const double A = 1;
        /// 5 B = 6
        private const double B = 1.2;
        private const double C = -20;
        private const double D = 0;


        static void Main()
        {
            while (true)
            {
                try
                {
                    string[] input = Console.ReadLine().Split();
                    int casesT = int.Parse(input[0]);
                    if (input.Length == 1 && casesT < 100 && casesT > 0)
                    {
                        input = new string[casesT];

                        for (int i = 0; i < casesT; i++)
                        {
                            input[i] = Console.ReadLine();
                            if (Convert.ToDouble(input[i]) > 1000 || Convert.ToDouble(input[i]) < -1000)
                            {
                                Console.WriteLine($"{input[i]} for evalution not in range [-1000, 1000]");
                                i--;
                            }
                        }
                    }

                    Console.WriteLine();
                    foreach (string testCaseNumber in input)
                    {
                        double x = float.Parse(testCaseNumber);
                        Console.WriteLine(
                            Math.Round(
                                (A * Math.Pow(x, 4)) +
                                (B * Math.Pow(x, 3)) +
                                (C * Math.Pow(x, 2)) +
                                (D * x) + E, 3
                            )
                        );
                    }

                    return;
                }
                catch
                {
                    Console.WriteLine("Invalid Input");
                }
                finally
                {
                    Console.ReadKey();
                }
            }
        }
    }
}
