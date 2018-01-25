using System;

namespace _04.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            long[][] triangle = new long[n][];
            for (long row = 0; row < triangle.Length; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[row][0] = 1;
                triangle[row][triangle[row].Length - 1] = 1;

                for (int i = 1; i < triangle[row].Length - 1; i++)
                {
                    triangle[row][i] = triangle[row - 1][i - 1] + triangle[row - 1][i];
                }
            }

            foreach (var row in triangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}