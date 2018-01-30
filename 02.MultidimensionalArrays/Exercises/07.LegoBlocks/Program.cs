using System;
using System.Linq;

namespace _07.LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int firstMatrixCells = 0;
            int secondMatrixCells = 0;

            int[][] firstMatrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                firstMatrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                firstMatrixCells += firstMatrix[row].Length;
            }

            int[][] secondMatrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                secondMatrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                secondMatrixCells += secondMatrix[row].Length;
            }
            int colsCount = firstMatrix[0].Length + secondMatrix[0].Length;

            bool areMatching = true;
            int counter = 1;
            while (counter < rows)
            {
                if (firstMatrix[counter].Length + secondMatrix[counter].Length != colsCount)
                {
                    areMatching = false;
                    break;
                }
                counter++;
            }
            if (!areMatching)
            {
                Console.WriteLine($"The total number of cells is: {firstMatrixCells + secondMatrixCells}");
            }
            else
            {
                for (int row = 0; row < rows; row++)
                {
                    Console.WriteLine($"[{string.Join(", ",firstMatrix[row])}, {string.Join(", ", secondMatrix[row].Reverse())}]");
                }
            }
        }
    }
}