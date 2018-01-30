using System;
using System.Linq;

namespace _04.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();

            int[][] matrix = new int[matrixSizes[0]][];
            for (int row = 0; row < matrixSizes[0]; row++)
            {
                matrix[row] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).ToArray();
            }
            long maxSum = long.MinValue;
            int[][] maxSumMatrix = new int[3][];

            for (int row = 0; row < matrixSizes[0] - 2; row++)
            {
                for (int col = 0; col < matrixSizes[1] - 2; col++)
                {
                    long currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                                     matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                                     matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSumMatrix = new int[3][]
                        {
                            new int[] { matrix[row][col], matrix[row][col + 1],matrix[row][col + 2]},
                            new int[] { matrix[row + 1][col], matrix[row + 1][col + 1], matrix[row + 1][col + 2] },
                            new int[] { matrix[row + 2][col], matrix[row + 2][col + 1], matrix[row + 2][col + 2] }
                        };
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            foreach (var row in maxSumMatrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}