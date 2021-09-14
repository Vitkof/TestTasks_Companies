using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WordSearch_Intetics
{
    class WordSearch
    {
        static int N;
        static readonly sbyte[] x = { -1, 0, 1, 0 };
        static readonly sbyte[] y = { 0, -1, 0, 1 };
        static readonly List<Node> path = new();
        static readonly List<Node> firsts = new();
        

        static void Main(string[] args)
        {

            int mem = (int)Process.GetCurrentProcess().WorkingSet64;
            var sw = new Stopwatch();
            sw.Start();

            string abrakadabr = args[0];
            string word = args[1];            
            var arr = FillMatrix(abrakadabr, word[0]);
            Search2D(arr, word);

            sw.Stop();
            Console.WriteLine($"Search: {word}" +
                $"\n{ShowPath()}" +
                $"\n Time spent: {sw.ElapsedMilliseconds}" +
                $"\n Memory: {mem / 1024}K");


            Console.ReadKey();           
        }


        static char[,] FillMatrix(string abrakadabr, char ch)
        {
            N = (int)Math.Sqrt(abrakadabr.Length);
            var arr = new char[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    arr[i, j] = abrakadabr[i * N + j];
                    if (arr[i, j] == ch)
                        firsts.Add(new Node(i, j));
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }
            return arr;
        }

        static bool SearchNextLetter(char[,] matrix, Node node, string word, byte ch)
        {
            if (ch < word.Length)
            {
                for (byte dir = 0; dir < 4; dir++)
                {
                    int rd = node.I + x[dir], cd = node.J + y[dir];
                    if (rd >= N || rd < 0 || cd >= N || cd < 0)
                        continue;
                    if (matrix[rd, cd] != word[ch])
                        continue;
                    if (path.Contains(new Node(rd, cd)))
                        continue;
                    path.Add(new Node(rd, cd));
                    ch++;
                    if (SearchNextLetter(matrix, new Node(rd, cd), word, ch)) //recursion
                        return true;
                    else
                    {
                        path.Remove(new Node(rd, cd));
                        ch--;                   // 1 step back in letters
                    }

                }
                return false;  // none of the admissible neighbors has the desired letter
            }
            return true;       // reached the end of the word
        }

        static void Search2D(char[,] arr, string word)
        {
            foreach(var el in firsts)
            {
                path.Add(el);
                byte k = 1;
                if (SearchNextLetter(arr, el, word, k))
                {
                    return;
                }
                else
                {
                    path.Clear();
                    continue;
                }
            }
        }

        static string ShowPath()
        {           
            if (path.Count != 0)
            {
                string strPath = "";
                foreach (var el in path)
                {
                    strPath += $"{el}->";
                }
                return strPath[0..^2];
            }
            else
                return "Not Found!";
        }
    }   
}