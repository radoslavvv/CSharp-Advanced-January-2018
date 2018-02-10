using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int[] matrixSizes = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[][] matrix = CreateMatrix(matrixSizes);

        long ivoValue = 0;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Let the Force be with you")
            {
                break;
            }

            int[] ivoPostition = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] enemyPosition = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            EnemyMove(matrixSizes, matrix, enemyPosition);

            ivoValue = IvoMove(matrixSizes, matrix, ivoValue, ivoPostition);
        }
        Console.WriteLine(ivoValue);
    }

    private static void EnemyMove(int[] matrixSizes, int[][] matrix, int[] enemyPosition)
    {
        while (enemyPosition[0] >= 0 && enemyPosition[1] >= 0)
        {
            if (IsInMatrix(enemyPosition[0], enemyPosition[1], matrixSizes[0], matrixSizes[1]))
            {
                matrix[enemyPosition[0]][enemyPosition[1]] = 0;
            }
            enemyPosition[0]--;
            enemyPosition[1]--;
        }
    }

    private static long IvoMove(int[] matrixSizes, int[][] matrix, long ivoValue, int[] ivoPostition)
    {
        while (ivoPostition[0] >= 0 && ivoPostition[1] < matrix[0].Length)
        {
            if (IsInMatrix(ivoPostition[0], ivoPostition[1], matrixSizes[0], matrixSizes[1]))
            {
                ivoValue += matrix[ivoPostition[0]][ivoPostition[1]];
            }

            ivoPostition[0]--;
            ivoPostition[1]++;
        }

        return ivoValue;
    }

    private static int[][] CreateMatrix(int[] matrixSizes)
    {
        int counter = 0;
        int[][] matrix = new int[matrixSizes[0]][];
        for (long row = 0; row < matrixSizes[0]; row++)
        {
            matrix[row] = new int[matrixSizes[1]];
            for (long col = 0; col < matrixSizes[1]; col++)
            {
                matrix[row][col] = counter;
                counter++;
            }
        }

        return matrix;
    }

    private static bool IsInMatrix(long row, long col, long matrixRows, long matrixCols)
    {
        return (row >= 0 && row < matrixRows) && (col >= 0 && col < matrixCols);
    }

}
