using System;
using System.Linq;

namespace _02.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = CreateMatrix(rowsAndCols);

            int maxSum = int.MinValue;
            int[,] maxSumElements = new int[2, 2];

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] +
                                     matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;

                        maxSumElements = new int[2, 2]
                        {
                                {matrix[row, col], matrix[row, col + 1] },
                                {matrix[row + 1, col], matrix[row + 1, col + 1]}
                        };
                    }
                }
            }

            PrintMaxSum(maxSum, maxSumElements);
        }

        private static void PrintMaxSum(int maxSum, int[,] maxSumElements)
        {
            for (int row = 0; row < maxSumElements.GetLength(0); row++)
            {
                for (int col = 0; col < maxSumElements.GetLength(1); col++)
                {
                    Console.Write($"{maxSumElements[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }

        private static int[,] CreateMatrix(int[] rowsAndCols)
        {
            int[,] matrix = new int[rowsAndCols[0], rowsAndCols[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine()
                     .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
    }
}