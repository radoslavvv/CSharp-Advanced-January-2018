using System;
using System.Linq;

namespace _02.CubicsRube
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long[,,] matrix = new long[n, n, n];

            string input = Console.ReadLine();
            long sum = 0;
            long notChangedCells = n * n * n;

            while (input != "Analyze")
            {
                long[] inputParams = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                    Select(long.Parse).ToArray();

                long row = inputParams[0];
                long col = inputParams[1];
                long depth = inputParams[2];

                long value = inputParams[3];

                if ((row >= 0 && row < n) &&
                     (col >= 0 && col < n) &&
                     (depth >= 0 && depth < n))
                {
                    matrix[row, col, depth] = value;
                    sum += value;
                    if (value != 0)
                    {
                        notChangedCells--;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
            Console.WriteLine(notChangedCells);
        }
    }
}