using System;
using System.Linq;

namespace _03._2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();

            char[][] matrix = new char[matrixSizes[0]][];
            for (int row = 0; row < matrixSizes[0]; row++)
            {
                matrix[row] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                    Select(char.Parse).ToArray();
            }

            int equalSquresCount = 0;
            for (int row = 0; row < matrixSizes[0] - 1; row++)
            {
                for (int col = 0; col < matrixSizes[1] - 1; col++)
                {
                    bool equalSqure = matrix[row][col] == matrix[row][col + 1] &&
                                      matrix[row][col] == matrix[row + 1][col] &&
                                      matrix[row + 1][col] == matrix[row + 1][col + 1];

                    if (equalSqure)
                    {
                        equalSquresCount++;
                    }
                }
            }
            Console.WriteLine(equalSquresCount);
        }
    }
}