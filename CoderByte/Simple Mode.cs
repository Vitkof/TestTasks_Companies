/*Using the C# language, have the function SimpleMode(arr) 
take the array of numbers stored in arr and return the number that 
appears most frequently (the mode). 

For example: if arr contains [10, 4, 5, 2, 4] the output should be 4. 
If there is more than one mode return the one that appeared in the 
array first (ie. [5, 10, 10, 6, 5] should return 5 because it appeared 
first). If there is no mode return -1. The array will not be empty. */

using System;

namespace ConsoleApp3
{
    class Program
    {
        public static int SimpleMode(int[] arr)
        {
            int mode = 0;
            int count2 = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j] && i != j)
                    {
                        count++;
                    }
                    if (count > count2)
                    {
                        mode = arr[i];
                        count2 = count;
                        count = 0;
                    }
                }
            }

            if (count2 == 0)
            {
                return -1;
            }

            return mode;
        }
    

        static void Main()
        {
            // keep this function call here
            Console.WriteLine(SimpleMode(new int[]{ 5, 10, 10, 6, 5 }));
        }
    }
}
