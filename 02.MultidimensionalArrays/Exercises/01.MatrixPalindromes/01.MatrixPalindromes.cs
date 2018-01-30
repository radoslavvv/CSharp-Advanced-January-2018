using System;
using System.Linq;

namespace _02.MultidimensionalArrays_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixParams = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[][] matrix = new string[matrixParams[0]][];

            for (int row = 0; row < matrixParams[0]; row++)
            {
                matrix[row] = new string[matrixParams[1]];
            }

            for (int row = 0; row < matrixParams[0]; row++)
            {
                for (int col = 0; col < matrixParams[1]; col++)
                {
                    string currentResult = $"{alphabet[row]}{alphabet[row + col]}{alphabet[row]}";
                    matrix[row][col] = currentResult;
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine($"{string.Join(" ", row)}");
            }
        }
    }
}