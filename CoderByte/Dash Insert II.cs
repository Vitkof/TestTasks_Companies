/*Using the C# language, have the function DashInsertII(str) 
insert dashes ('-') between each two odd numbers 
and insert asterisks ('*') between each two even numbers in str.
For example: if str is 4546793 the output should be 454*67-9-3. 
Don't count zero as an odd or even number.*/

using System;
using System.Text;

namespace ConsoleApp3
{
    class Program
    {
        public static string DashInsertII(string num)
        {
            var arr = num.ToCharArray();
            var sb = new StringBuilder(arr[0].ToString(), arr.Length);

            for (var i = 0; i < arr.Length-1; i++)
            {
                if(arr[i] != 48 && arr[i+1] != 48) //'0' = 48
                {
                    if (arr[i] % 2 == 0 && arr[i + 1] % 2 == 0)
                    {
                        sb.Append('*');
                    }
                    else if (arr[i] % 2 != 0 && arr[i + 1] % 2 != 0)
                    {
                        sb.Append('-');
                    }
                }
                
                sb.Append(arr[i+1]);
            }

            return sb.ToString();
        }

        static void Main()
        {
            // keep this function call here
            Console.WriteLine(DashInsertII(Console.ReadLine()));
        }
    }
}
