using System;
using System.Text.RegularExpressions;

namespace Task2
{
    class Program
    {        
        private byte _n;
        private byte _m;
        private double _a;

        public byte N {
            get { return _n; }
            set { if(ValidateN(value)) _n = value;
                else throw new Exception("4 <= N <= 10, N is even"); }
        }
        public byte M { 
            get { return _m; }
            set { if (ValidateM(value)) _m = value;
                else throw new Exception("N <= M <= 20"); }
        }
        public double A {
            get { return _a; }
            set { if (ValidateA(value)) _a = value;
                else throw new Exception("0 < a[i] <= 3000");
            }
        }


        static void Main()
        {
            var prog = new Program();
            Console.WriteLine("Format\n4 4\n3000\n3000\n1000\n1000\n____");
            string nM = Console.ReadLine();             
            prog.Calculate(nM);
        }


        private static bool ValidateN(byte n) {
            return n >= 4 && n <= 10 && n % 2 == 0; 
        }
        private bool ValidateM(byte m) {
            return N <= m && m <= 20;
        }
        private static bool ValidateA(double m) {
            return 0 < m && m <= 3000;
        }


        private void Calculate(string input0)
        {
            var regex = new Regex(" +");
            string[] arr = regex.Split(input0.Trim());
            double wearPer1km = 0.0;
            
            try
            {
                N = Convert.ToByte(arr[0]);
                M = Convert.ToByte(arr[1]);               

                for (int i = 0; i < N; i++)
                {
                    A = Convert.ToDouble(Console.ReadLine());
                    wearPer1km += 1 / A;
                }
                Console.WriteLine("{0:0.000}", M / wearPer1km);

            }
            catch (FormatException)
            {
                Console.WriteLine("Input array of strings is not a sequence of digits.");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }        
    }
}
