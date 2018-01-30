using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _12.StringMatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            int rotations = int.Parse(input[1]);

            List<string> words = new List<string>();
            int longestWord = int.MinValue;

            string command = Console.ReadLine();
            while (command != "END")
            {
                words.Add(command);
                if (command.Length > longestWord)
                {
                    longestWord = command.Length;
                }
                command = Console.ReadLine();
            }

            char[][] matrix = CreateMatrix(words, longestWord);
            int[] basicRotations = new int[] { 0, 90, 180, 270 };
            if (!basicRotations.Contains(rotations))
            {
                int realRotations = (rotations / 90) % 4;

                PrintMatrix(basicRotations[realRotations], matrix);
            }
            else
            {
                PrintMatrix(rotations, matrix);
            }
        }

        private static char[][] CreateMatrix(List<string> words, int longestWord)
        {
            char[][] matrix = new char[words.Count][];
            for (int row = 0; row < words.Count; row++)
            {
                matrix[row] = new char[longestWord];

                // SET ALL ITEMS TO ' '
                matrix[row] = matrix[row].Select(w => ' ').ToArray();

                for (int col = 0; col < words[row].Length; col++)
                {
                    matrix[row][col] = words[row][col];
                }
            }
            return matrix;
        }

        private static void PrintMatrix(int rotations, char[][] matrix)
        {
            char[][] result = new char[matrix.Length][];
            if (rotations == 0)
            {
                foreach (var row in matrix)
                {
                    Console.WriteLine($"{string.Join("", row)}");
                }
            }
            else if (rotations == 90)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    for (int row = matrix.Length - 1; row >= 0; row--)
                    {
                        Console.Write($"{matrix[row][col]}");
                    }
                    Console.WriteLine();
                }
            }
            else if (rotations == 180)
            {
                for (int row = matrix.Length - 1; row >= 0 ; row--)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        Console.Write($"{matrix[row][col]}");
                    }
                    Console.WriteLine();
                }
            }
            else if (rotations == 270)
            {
                for (int col = matrix[0].Length - 1; col >= 0; col--)
                {
                    for (int row = 0; row < matrix.Length; row++)
                    {
                        Console.Write($"{matrix[row][col]}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}