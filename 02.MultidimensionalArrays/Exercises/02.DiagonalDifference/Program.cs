using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixSize][];

            int leftSum = 0;
            int rightSum = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                matrix[row] = Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                leftSum += matrix[row][row];
                rightSum += matrix[row][matrixSize - 1 - row];
            }

            Console.WriteLine(Math.Abs(leftSum - rightSum));
        }
    }
}