using System;
using System.Linq;

namespace _08.RadioactiveBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int totalRows = matrixParams[0];
            int totalCols = matrixParams[1];

            int[] playerPosition = new int[2];
            char[][] matrix = new char[totalRows][];
            for (int row = 0; row < matrixParams[0]; row++)
            {
                matrix[row] = Console.ReadLine()
                    .ToCharArray();

                if (matrix[row].Contains('P'))
                {
                    int playerCol = Array.IndexOf(matrix[row], 'P');

                    playerPosition[0] = row;
                    playerPosition[1] = playerCol;
                }
            }

            bool playerIsDead = false;
            bool playerWon = false;

            char[] commands = Console.ReadLine().ToCharArray();
            foreach (char command in commands)
            {
                int playerRow = playerPosition[0];
                int playerCol = playerPosition[1];

                if (command == 'U')
                {
                    if (IsInsideTheMatrix(playerRow - 1, playerCol, totalRows, totalCols))
                    {
                        if (matrix[playerRow - 1][playerCol] != 'B')
                        {
                            matrix[playerRow - 1][playerCol] = 'P';
                        }
                        else if (matrix[playerRow - 1][playerCol] == 'B')
                        {
                            playerIsDead = true;
                        }

                        playerPosition[0] = playerRow - 1;
                        playerPosition[1] = playerCol;
                    }
                    else
                    {
                        playerWon = true;
                    }
                }
                else if (command == 'D')
                {
                    if (IsInsideTheMatrix(playerRow + 1, playerCol, totalRows, totalCols))
                    {
                        if (matrix[playerRow + 1][playerCol] != 'B')
                        {
                            matrix[playerRow + 1][playerCol] = 'P';
                        }
                        else if (matrix[playerRow + 1][playerCol] == 'B')
                        {
                            matrix[playerRow][playerCol] = '.';
                            playerIsDead = true;
                        }

                        playerPosition[0] = playerRow + 1;
                        playerPosition[1] = playerCol;
                    }
                    else
                    {
                        playerWon = true;
                    }
                }
                else if (command == 'L')
                {
                    if (IsInsideTheMatrix(playerRow, playerCol - 1, totalRows, totalCols))
                    {
                        if (matrix[playerRow][playerCol - 1] != 'B')
                        {
                            matrix[playerRow][playerCol - 1] = 'P';
                        }
                        else if (matrix[playerRow][playerCol - 1] == 'B')
                        {
                            playerIsDead = true;
                        }

                        playerPosition[0] = playerRow;
                        playerPosition[1] = playerCol - 1;
                    }
                    else
                    {
                        playerWon = true;
                    }
                }
                else if (command == 'R')
                {
                    if (IsInsideTheMatrix(playerRow, playerCol + 1, totalRows, totalCols))
                    {
                        if (matrix[playerRow][playerCol + 1] != 'B')
                        {
                            matrix[playerRow][playerCol + 1] = 'P';
                        }
                        else if (matrix[playerRow][playerCol + 1] == 'B')
                        {
                            playerIsDead = true;
                        }
                        playerPosition[0] = playerRow;
                        playerPosition[1] = playerCol + 1;
                    }
                    else
                    {
                        playerWon = true;
                    }
                }

                matrix[playerRow][playerCol] = '.';

                for (int row = 0; row < totalRows; row++)
                {
                    for (int col = 0; col < totalCols; col++)
                    {
                        char currentPosition = matrix[row][col];
                        if (currentPosition == 'B')
                        {
                            //top
                            if (IsInsideTheMatrix(row + 1, col, totalRows, totalCols))
                            {
                                if (matrix[row + 1][col] == 'P')
                                {
                                    playerIsDead = true;
                                }
                                else if (matrix[row + 1][col] != 'B')
                                {
                                    matrix[row + 1][col] = '-';
                                }
                            }
                            //bot
                            if (IsInsideTheMatrix(row - 1, col, totalRows, totalCols))
                            {
                                if (matrix[row - 1][col] == 'P')
                                {
                                    playerIsDead = true;
                                }
                                else if (matrix[row - 1][col] != 'B')
                                {
                                    matrix[row - 1][col] = '-';
                                }
                            }
                            //left
                            if (IsInsideTheMatrix(row, col - 1, totalRows, totalCols))
                            {
                                if (matrix[row][col - 1] == 'P')
                                {
                                    playerIsDead = true;
                                }
                                else if (matrix[row][col - 1] != 'B')
                                {
                                    matrix[row][col - 1] = '-';
                                }

                            }
                            //right
                            if (IsInsideTheMatrix(row, col + 1, totalRows, totalCols))
                            {
                                if (matrix[row][col + 1] == 'P')
                                {
                                    playerIsDead = true;
                                }
                                else if (matrix[row][col + 1] != 'B')
                                {
                                    matrix[row][col + 1] = '-';
                                }

                            }
                        }
                    }
                }
                for (int row = 0; row < totalRows; row++)
                {
                    for (int col = 0; col < totalCols; col++)
                    {
                        if (matrix[row][col] == '-')
                        {
                            matrix[row][col] = 'B';
                        }
                    }
                }

                if (playerIsDead)
                {
                    matrix[playerPosition[0]][playerPosition[1]] = 'B';
                    foreach (var row in matrix)
                    {
                        Console.WriteLine($"{string.Join("", row)}");
                    }
                    Console.WriteLine($"dead: {playerPosition[0]} {playerPosition[1]}");
                    break;
                }
                else if (playerWon)
                {
                    foreach (var row in matrix)
                    {
                        Console.WriteLine($"{string.Join("", row)}");
                    }
                    Console.WriteLine($"won: {playerPosition[0]} {playerPosition[1]}");

                    break;
                }
            }
        }

        private static bool IsInsideTheMatrix(int row, int col, int totalRows, int totalCols)
        {

            if (row >= 0 && row <= totalRows - 1)
            {
                if (col >= 0 && col <= totalCols - 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}