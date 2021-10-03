using System;
using System.Text.RegularExpressions;

namespace Task4
{
    class Program
    {
        private static short _n;
        private static short _m;

        public static short N
        {
            get { return _n; }
            set { if (Valid1000(value)) _n = value;
                else throw new NumberException(value); }
        }
        public static short M
        {
            get { return _m; }
            set { if(Valid1000(value)) _m = value;
                else throw new NumberException(value); }
        }


        static void Main()
        {
            Console.Write("Enter 2 numbers [range(1,1000)] separated by a space: ");
            Calculate(Console.ReadLine());
        }


        private static void Calculate(string input)
        {
            string excMessage = Validate(input);
            if (!String.IsNullOrEmpty(excMessage))
            { Console.WriteLine(excMessage); return; }
                

            int length = N + M + 1;
            sbyte[] arrMouse = new sbyte[length];

            for (int i = 0; i < N; i++)
                arrMouse[i] = -1;
            arrMouse[N] = 0;             //пустая разделительная клетка
            for (int i = N + 1; i < length; i++)
                arrMouse[i] = 1;
            //because Do-while
            int count = -1;

            do
            {
                count++;
                Drawing(arrMouse);
            }
            while (RuleStep(arrMouse, N));

            Console.WriteLine($"N: {N}, M: {M}, Count: {count}");
            
        }


        private static bool Valid1000(short value)
        {
            return value >= 1 && value <= 1000;
        }


        private static string Validate(string str)
        {
            try
            {
                var reg = new Regex(" +");
                string[] arr = reg.Split(str.Trim());

                N = Convert.ToInt16(arr[0].Trim());
                M = Convert.ToInt16(arr[1].Trim());
            }
            catch (IndexOutOfRangeException)
            {
                return "You didn't enter 2 numbers.";
            }
            catch (OverflowException ex)
            {
                return ex.Message;
            }
            catch (FormatException)
            {
                return "Input string is not a sequence of digits.";
            }
            catch (NumberException ex)
            {
                return $"{ex.Value}: {ex.Msg}";
            }
            return null;
        }


        private static bool RuleStep(sbyte[] a, int n)
        {
            int rank = a.Length;

            /* Логика: Постараться сперва перепрыгивать через противоположный цвет,
                   а потом уже при невозможности, двигать на соседнюю пустую  */
            for (int i = 0; i < rank; i++)
            {
                if (i < rank - 2 && a[i] == -1 && a[i + 1] == 1 && a[i + 2] == 0)
                {
                    a[i] = 0;
                    a[i + 2] = -1;
                    return true;
                }

                else if (i > 1 && a[i] == 1 && a[i - 1] == -1 && a[i - 2] == 0)
                {
                    a[i] = 0;
                    a[i - 2] = 1;
                    return true;
                }
            }

            for (int i = 0; i < rank; i++)
            {
                /*Заходим в этот цикл, если перескока ч/з 1 нет*/
                if (a[i] == 0)
                {
                    if (i == 0)
                    {
                        a[i] = 1;
                        a[i + 1] = 0;
                        return true;
                    }

                    else if (i < rank - 1)
                    {
                        if (a[i - 1] == -1 || a[i + 1] == 1)
                        {
                            if (a[i - 1] == a[i + 1])  // 1 1 -1 0 -1;   1 0 1 -1 -1 
                            {
                                if (a[i + 1] == -1)
                                {
                                    a[i] = -1;
                                    a[i - 1] = 0;
                                    return true;
                                }
                                if (a[i - 1] == 1)
                                {
                                    a[i] = 1;
                                    a[i + 1] = 0;
                                    return true;
                                }
                            }

                            else
                            {
                                if (i > n)
                                {
                                    a[i] = 1;
                                    a[i + 1] = 0;
                                    return true;
                                }
                                else
                                {
                                    a[i] = -1;
                                    a[i - 1] = 0;
                                    return true;
                                }
                            }
                        }
                    }

                    else
                    {
                        a[i] = -1;
                        a[i - 1] = 0;
                        return true;
                    }
                }
            }
            return false;
        }


        
        private static void Drawing(sbyte[] array)
        {
            if (array.Length <= 60)
            {
                foreach (var item in array)
                {
                    if (item == -1) Console.ResetColor();
                    else if (item == 1) Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }            
        }        
    }
}
