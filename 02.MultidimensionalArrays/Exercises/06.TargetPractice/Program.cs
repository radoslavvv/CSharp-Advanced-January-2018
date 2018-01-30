using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();

            int matrixRows = matrixSizes[0];
            int matrixCols = matrixSizes[1];

            string text = Console.ReadLine();
            char[][] matrix = CreateMatrix(matrixSizes, text);
            int[] shotParams = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            ShootSnakes(matrixRows, matrixCols, matrix, shotParams);
            FixSpaces(matrixRows, matrixCols, matrix);
            PrintMatrix(matrix);
        }

        static bool IsCellWithinRadius(int currRow, int currCol, int centerRow, int centerCol, int radius)
        {
            bool isInRange = false;
            isInRange = ((currRow - centerRow) * (currRow - centerRow)) +
                        ((currCol - centerCol) * (currCol - centerCol)) <= radius * radius;

            return isInRange;
        }

        private static void ShootSnakes(int matrixRows, int matrixCols, char[][] matrix, int[] shotParams)
        {
            int impactRow = shotParams[0];
            int impactCol = shotParams[1];
            int impactRadius = shotParams[2];

            for (int row = impactRow - impactRadius; row <= impactRow + impactRadius; row++)
            {
                if (row >= 0 && row < matrixRows)
                {
                    for (int col = impactCol - impactRadius; col <= impactCol + impactRadius; col++)
                    {
                        if (col >= 0 && col < matrixCols)
                        {
                            if (IsCellWithinRadius(row, col, impactRow, impactCol, impactRadius))
                            {
                                matrix[row][col] = ' ';
                            }
                        }
                    }
                }
            }
        }

        private static void FixSpaces(int matrixRows, int matrixCols, char[][] matrix)
        {
            bool shifted = true;
            while (shifted)
            {
                shifted = false;
                for (int row = matrixRows - 1; row >= 0; row--)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == ' ' && row != 0 && matrix[row - 1][col] != ' ')
                        {
                            matrix[row][col] = matrix[row - 1][col];
                            matrix[row - 1][col] = ' ';

                            shifted = true;
                        }
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine($"{string.Join("", row)}");
            }
        }

        private static char[][] CreateMatrix(int[] matrixSizes, string text)
        {
            char[][] matrix = new char[matrixSizes[0]][];
            string direction = "left";
            int counter = 0;
            for (int row = matrixSizes[0] - 1; row >= 0; row--)
            {
                matrix[row] = new char[matrixSizes[1]];
                if (direction == "left")
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        if (counter == text.Length)
                        {
                            counter = 0;
                        }
                        matrix[row][col] = text[counter];
                        counter++;
                    }
                    direction = "right";
                }
                else if (direction == "right")
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (counter == text.Length)
                        {
                            counter = 0;
                        }
                        matrix[row][col] = text[counter];
                        counter++;
                    }
                    direction = "left";
                }
            }
            return matrix;
            
        }
    }
}
