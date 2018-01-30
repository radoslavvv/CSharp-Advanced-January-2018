using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.CrossFire
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] matrixSizes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            long matrixRows = matrixSizes[0];
            long matrixCols = matrixSizes[1];

            List<List<int>> matrix = CreateMatrix(matrixRows, matrixCols);

            string input = Console.ReadLine();
            while (input != "Nuke it from orbit")
            {
                int[] shotParams = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int impactRow = shotParams[0];
                int impactCol = shotParams[1];
                int impactRadius = shotParams[2];

                for (int row = 0; row < matrix.Count; row++)
                {
                    for (int col = 0; col < matrix[row].Count; col++)
                    {
                        if ((row == impactRow && Math.Abs(col - impactCol) <= impactRadius) ||
                            (col == impactCol && Math.Abs(row - impactRow) <= impactRadius))
                        {
                            matrix[row][col] = 0;
                        }
                    }
                }

                for (int row = 0; row < matrix.Count; row++)
                {
                    matrix[row].RemoveAll(e => e == 0);
                    if (matrix[row].Count == 0)
                    {
                        matrix.RemoveAt(row);
                        row--;
                    }
                }
                input = Console.ReadLine();
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine($"{string.Join(" ", row)}");
            }
        }

        private static List<List<int>> CreateMatrix(long matrixRows, long matrixCols)
        {
            List<List<int>> matrix = new List<List<int>>();
            int counter = 1;
            for (int row = 0; row < matrixRows; row++)
            {
                matrix.Add(new List<int>());
                for (int col = 0; col < matrixCols; col++)
                {
                    matrix[row].Add(counter);
                    counter++;
                }
            }

            return matrix;
        }
    }
}