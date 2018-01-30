using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).ToArray();
            int[][] matrix = CreateMatrix(matrixSizes);

            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] currentCommand = Console.ReadLine().
                    Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                ShiftMatrix(matrixSizes, matrix, currentCommand);
            }
            PrintMatrix(matrixSizes, matrix);
        }

        private static void PrintMatrix(int[] matrixSizes, int[][] matrix)
        {
            int count = 1;
            for (int row = 0; row < matrixSizes[0]; row++)
            {
                for (int col = 0; col < matrixSizes[1]; col++)
                {
                    if (matrix[row][col] != count)
                    {
                        int[] numberLocation = FindNumber(matrix, count);
                        Console.WriteLine($"Swap ({row}, {col}) with ({numberLocation[0]}, {numberLocation[1]})");
                        matrix[numberLocation[0]][numberLocation[1]] = matrix[row][col];
                        matrix[row][col] = count;
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }

                    count++;
                }
            }
        }

        private static void ShiftMatrix(int[] matrixSizes, int[][] matrix, string[] currentCommand)
        {
            if (currentCommand[1] == "down" || currentCommand[1] == "up")
            {
                int colIndex = int.Parse(currentCommand[0]);
                int moves = int.Parse(currentCommand[2]) % matrixSizes[1];

                int[] currentCol = new int[matrixSizes[0]];

                for (int row = 0; row < matrixSizes[0]; row++)
                {
                    currentCol[row] = matrix[row][colIndex];
                }

                if (currentCommand[1] == "down")
                {
                    Queue<int> col = new Queue<int>(currentCol.Reverse().ToArray());

                    for (int j = 0; j < moves; j++)
                    {
                        col.Enqueue(col.Dequeue());
                    }
                    col = new Queue<int>(col.Reverse());

                    for (int j = 0; j < matrixSizes[0]; j++)
                    {
                        matrix[j][colIndex] = col.Dequeue();
                    }
                }
                else if (currentCommand[1] == "up")
                {
                    Queue<int> col = new Queue<int>(currentCol.ToArray());
                    for (int j = 0; j < moves; j++)
                    {
                        col.Enqueue(col.Dequeue());
                    }
                    for (int j = 0; j < matrixSizes[0]; j++)
                    {
                        matrix[j][colIndex] = col.Dequeue();
                    }
                }

            }
            else if (currentCommand[1] == "left" || currentCommand[1] == "right")
            {
                int rowIndex = int.Parse(currentCommand[0]);
                int moves = int.Parse(currentCommand[2]) % matrixSizes[1];

                if (currentCommand[1] == "left")
                {
                    Queue<int> row = new Queue<int>(matrix[rowIndex]);

                    for (int j = 0; j < moves; j++)
                    {
                        row.Enqueue(row.Dequeue());
                    }
                    matrix[rowIndex] = row.ToArray();
                }
                else if (currentCommand[1] == "right")
                {
                    Queue<int> row = new Queue<int>(matrix[rowIndex].Reverse().ToArray());

                    for (int j = 0; j < moves; j++)
                    {
                        row.Enqueue(row.Dequeue());
                    }
                    matrix[rowIndex] = row.Reverse().ToArray();
                }
            }
        }

        private static int[][] CreateMatrix(int[] matrixSizes)
        {
            int[][] matrix = new int[matrixSizes[0]][];
            int counter = 1;
            for (int row = 0; row < matrixSizes[0]; row++)
            {
                matrix[row] = new int[matrixSizes[1]];
                for (int col = 0; col < matrixSizes[1]; col++)
                {
                    matrix[row][col] = counter;
                    counter++;
                }

            }

            return matrix;
        }

        private static int[] FindNumber(int[][] matrix, int number)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == number)
                    {
                        return new int[] {row, col};
                    }
                }
            }
            return null;
        }
    }
}